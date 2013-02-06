﻿using System.Collections.Generic;
using System.Web.Http;
using WebApi.BLL;
using WebApi.BLL.Entities;
using System.Web.Http.Description;
using System.Web.Http.Tracing;
using System;
using System.Net.Http;
using System.Net;
using System.Linq;
using System.Web.Http.Controllers;
using System.Threading;
using System.Web.Http.Dispatcher;
using System.Web.Http.Filters;

namespace WebApi.Web.Http.Controllers
{
    [MyAuthorize]
    public class ProductsController : ApiController
    {
        private readonly IProductService productService;

        public ProductsController()
        {
            this.productService = new ProductServiceFactory().GetProductService();
        }

        public IEnumerable<Category> GetCategories()
        {
            var writer = base.Configuration.Services.GetTraceWriter();

            if (writer != null)
            {
                writer.Trace(base.Request, "ProductsController", TraceLevel.Info, r => r.Message = "Get categories");
            }

            return this.productService.GetCategories();
        }

        [MyAuthorize]
        public IEnumerable<Product> GetProducts(int categoryId)
        {
            return this.productService.GetProducts(categoryId);
        }

        [HttpPost]
        [AcceptVerbs("POST", "PUT")]
        public Product InsertProduct(Product product)
        {
            return product;
        }
    }
}