﻿using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

internal class Program
{
    private static void Main(string[] args)
    {
        ProductTest();

        //CategoryTest();

    }

    private static void CategoryTest()
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        foreach (var item in categoryManager.GetAll().Data)
        {
            Console.WriteLine(item.CategoryName);
        }
    }

    private static void ProductTest()
    {
        ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));

        var result = productManager.GetProductDetails();

        if(result.Success)
        {
            foreach (var product in result.Data)
            {
                Console.WriteLine(product.ProductName + "/" + product.CategoryName);
            }
        }
        else
        {
            Console.WriteLine(result.Message);
        }

    }
}