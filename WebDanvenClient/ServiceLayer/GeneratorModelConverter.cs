using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using WebDanvenClient.Models;

namespace WebDanvenClient.ServiceLayer {
    public class GeneratorModelConverter {

        internal static GeneratorServiceReference.Generator ConvertFromClientGeneratorToServiceGenerator (ClientGenerator clientGenerator) {
            GeneratorServiceReference.Customer customer = ConvertFromClientCustomerToServiceCustomer(clientGenerator.Customer);
            GeneratorServiceReference.Product product = ConvertFromClientProductToServiceProduct(clientGenerator.Product);
            GeneratorServiceReference.Generator generator = new GeneratorServiceReference.Generator() {
                TypeNumber = clientGenerator.TypeNumber,
                SerialNumber = clientGenerator.SerialNumber,
                RunningHours = clientGenerator.RunningHours,
                InstallationDate = clientGenerator.InstallationDate,
                GeneratorApplication = clientGenerator.GeneratorApplication,
                ErrorDescription = clientGenerator.ErrorDescription,
                AdditionalInformation = clientGenerator.AdditionalInformation,
                Customer = customer,
                Product = product
            };
            return generator;
        }

        private static GeneratorServiceReference.Customer ConvertFromClientCustomerToServiceCustomer(ClientCustomer clientCustomer) {
            GeneratorServiceReference.Customer customer = new GeneratorServiceReference.Customer() {
                CompanyName = clientCustomer.CompanyName,
                CompanyAddress = clientCustomer.CompanyAddress,
                ContactPersonName = clientCustomer.ContactPersonName,
                Email = clientCustomer.Email,
                Telephone = clientCustomer.Telephone
            };
            return customer;
        }

        private static GeneratorServiceReference.Product ConvertFromClientProductToServiceProduct(ClientProduct clientProduct) {
            GeneratorServiceReference.Product product = new GeneratorServiceReference.Product() {
                ProductType = clientProduct.ProductType,
                ProductSerialNumber = clientProduct.ProductSerialNumber,
                InvoiceNumber = clientProduct.InvoiceNumber
            };
            return product;
      }
    }
}