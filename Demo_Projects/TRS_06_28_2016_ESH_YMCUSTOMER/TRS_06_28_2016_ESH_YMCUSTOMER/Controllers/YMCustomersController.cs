using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRS_06_28_2016_ESH_YMCUSTOMER.Models;
using ESH_YMCUSTOMER.Data.Models;
using System.Data.Entity;
using TRS_06_28_2016_ESH_YMCUSTOMER.Helpers;
using AutoMapper;
using ESH_YMCUSTOMER.Data.Repositories;

using System.Data.SqlClient;
using System.Configuration;


namespace TRS_06_28_2016_ESH_YMCUSTOMER.Controllers
{
    public class YMCustomersController : Controller
    {
        private ESHDataModel _dbContext;
        private ym_customersRepository customerRepository;

        public YMCustomersController()
        {
            _dbContext = new ESHDataModel();
            customerRepository = new ym_customersRepository(_dbContext);
            
        }
        public ActionResult Index()
        {
            List<String> displayOrder = new List<String>(new String[] { "ym_customer_id", "customer_name", "customer_notes" });
            YMCustomersIndexViewModel ymcustomers = new YMCustomersIndexViewModel(displayOrder);
            var tempymcustomers = _dbContext.ym_customers;

            var results = customerRepository.GetCustomers();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ym_customers, YMCustomersCreateViewModel>();
            });

            var dest = Mapper.Map<IEnumerable<ym_customers>, List<YMCustomersCreateViewModel>>(results);
            ymcustomers.YMCustomers = dest;


            return View(ymcustomers);

        }

        // GET: YMCustomers/Details/5
        public ActionResult Details(int id)
        {
            var orderedProperties = OrderedPropertiesHelper.GetSortedProperties<YMCustomersCreateViewModel>();
            ViewBag.OrderedList = orderedProperties.ToList();
            var result = customerRepository.GetCustomerById(id);


            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ym_customers, YMCustomersCreateViewModel>();
            });

            var dest = Mapper.Map<ym_customers, YMCustomersCreateViewModel>(result);


            return View(dest);
        }
        /*
        // GET: YMCustomers/Create
        public ActionResult Create()
        {
            YMCustomersCreateViewModel customercreate = new YMCustomersCreateViewModel();
            return View(customercreate);
        }

        // POST: YMCustomers/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            YMCustomersCreateViewModel customercreate = new YMCustomersCreateViewModel();

            var orderedProperties = OrderedPropertiesHelper.GetSortedProperties<YMCustomersCreateViewModel>();
            ViewBag.OrderedList = orderedProperties.ToList();
            //return View(test.ToList());
            return View(customercreate);
        }*/

        // GET: YMCustomers/Create2
        public ActionResult Create()
        {
            YMCustomersCreateViewModel customercreate = new YMCustomersCreateViewModel();
            
            var orderedProperties = OrderedPropertiesHelper.GetSortedProperties<YMCustomersCreateViewModel>();
            ViewBag.OrderedList = orderedProperties.ToList();
            //return View(test.ToList());
            return View(customercreate);
        }

        // POST: YMCustomers/Create2
        [HttpPost]

        
        //public ActionResult Create2(FormCollection collection)
        public ActionResult Create([Bind(Exclude = "ym_customer_id", Include = "customer_name,customer_notes,customer_start_date,customer_end_date,mileage,freight_per_car,freight_per_unit,price_unit_id,surcharge_flag,cars_required_per_week,product_type")] YMCustomersCreateViewModel ymModel)
        {
            var orderedProperties = OrderedPropertiesHelper.GetSortedProperties<YMCustomersCreateViewModel>();
            ViewBag.OrderedList = orderedProperties.ToList();
            try
            {
                if (ModelState.IsValid)
                {
                    Mapper.Initialize(cfg =>
                    {
                        cfg.CreateMap<YMCustomersCreateViewModel, ym_customers>();
                    });

                    var dest = Mapper.Map<YMCustomersCreateViewModel, ym_customers>(ymModel);
                    int newRecordId = customerRepository.InsertCustomer(dest);


                    return RedirectToAction("Details",new { id = newRecordId });
                    // return RedirectToAction("Details/" + newRecordId.ToString());
                }

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index");
            }
        }


        // GET: YMCustomers/Edit/5
        public ActionResult Edit(int id)
        {
           
            YMCustomersCreateViewModel customercreate = new YMCustomersCreateViewModel();

            var orderedProperties = OrderedPropertiesHelper.GetSortedProperties<YMCustomersCreateViewModel>();
            ViewBag.OrderedList = orderedProperties.ToList();
            var result = customerRepository.GetCustomerById(id);


            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ym_customers, YMCustomersCreateViewModel>();
            });

            var dest = Mapper.Map<ym_customers, YMCustomersCreateViewModel> (result);


            return View(dest);
        }

        // POST: YMCustomers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,[Bind(Include = "ym_customer_id,customer_notes,customer_start_date,customer_name,customer_end_date,mileage,freight_per_car,freight_per_unit,price_unit_id,surcharge_flag,cars_required_per_week,product_type")] YMCustomersCreateViewModel returnModel)
        {
            try
            {
                returnModel.ym_customer_id = id;

                var orderedProperties = OrderedPropertiesHelper.GetSortedProperties<YMCustomersCreateViewModel>();
                ViewBag.OrderedList = orderedProperties.ToList();
                if (ModelState.IsValid)
                {
                    Mapper.Initialize(cfg =>
                    {
                        cfg.CreateMap<YMCustomersCreateViewModel, ym_customers>();
                    });

                    var dest = Mapper.Map<YMCustomersCreateViewModel, ym_customers>(returnModel);
                    customerRepository.UpdateCustomer(dest);

                  
                    return RedirectToAction("Details", new { id = id });
                    // return RedirectToAction("Details/" + newRecordId.ToString());
                }else
                {
                   
                    return View();
                }



            }
            catch(Exception ex)
            {

                return RedirectToAction("Index");
            }
        }

        // GET: YMCustomers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: YMCustomers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
