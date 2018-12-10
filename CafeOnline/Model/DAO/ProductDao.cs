﻿using Model.EF;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;

namespace Model.DAO
{
    public class ProductDao
    {
        /**
         * Constants
         */
        private ShopDbContext db = null;

        /**
         * @description -- init
         */

        public ProductDao()
        {
            db = new ShopDbContext();
        }

        private static ProductDao instance;

        public static ProductDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductDao();
                }
                return instance;
            }
        }

        /**
         * @description -- get Product by ProdID
         * @param _key: int -- is field ProdID
         */

        public Product getByID(int _key)
        {
            return db.Product.SingleOrDefault(obj => obj.ProdID == _key);
        }

        /**
         * @description -- check exits product in table Product
         * @param _prod: Product -- is a transion object
         */

        public bool hasProcuct(Product _prod)
        {
            var product = db.Product.SingleOrDefault(obj => obj.ProdID == _prod.ProdID);
            return product != default(Product) ? true : false;
        }

        /**
         * @description -- insert a product
         * @param _request: Product -- entity object
         */

        public bool insert(Product _request)
        {
            if (!hasProcuct(_request))
            {
                _request.CreatedAt = DateTime.Now;
                db.Product.Add(_request);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /**
         * @description -- delete a product
         * @param _key: int -- is field ProdID
         */

        public bool delete(int _key)
        {
            if (hasReference(_key))
                return false;
            db.Product.Remove(getByID(_key));
            db.SaveChanges();
            return true;
        }

        /**
         * @description -- change status active
         * @param _key: int -- is field ProdID
         */

        public bool changeStatus(int _key)
        {
            var product = getByID(_key);
            product.isActive = !product.isActive;
            product.UpdatedAt = DateTime.Now;
            db.SaveChanges();
            return product.isActive;
        }

        /**
         * @description -- update info product has image
         * @param _request: ProductRequestDto -- is the data transmitted down from the display screen
         */

        public bool update(Product _request)
        {
                var product = getByID(_request.ProdID);
                product.ProdName = _request.ProdName;
                product.Decription = _request.Decription;
                product.Cost = _request.Cost;
                product.ImageUrl = _request.ImageUrl;
                product.UpdatedAt = DateTime.Now;
                product.isActive = _request.isActive;
                db.SaveChanges();
                return true;
        }


        public IEnumerable<Product> ListAllPaging(int page)
        {
            IQueryable<Product> model = db.Product;
            return model.OrderByDescending(x => x.CreatedAt).ToPagedList(page, Constants.PageSize);

        }

        /**
         * @description -- get products list by search key
         * @param _search: string -- is search key
         */

        public IEnumerable<Product> getObjectList(string _search)
        {
            var model = db.Product.ToList();
            if (_search != null)
            {
                model = model.Where(obj => obj.ProdName.Contains(_search)).ToList();
            }

            return model;
        }

        /**
         * @private
         * @description -- check the existence of image
         * @param imagefilePath: string -- is the path of the image file
         */


        public List<Product> ListNewProduct(int top)
        {
            return db.Product.OrderByDescending(x => x.CreatedAt).Take(top).ToList();
        }

        private bool hasReference(int _key)
        {
            var product = getByID(_key);
            if (product != default(Product))
            {
                var count_one = db.Order.Where(obj => obj.ProdID == _key).ToList().Count;
                return count_one > Constants.zeroNumber;
            }
            return Constants.falseValue;
        }
    }
}
