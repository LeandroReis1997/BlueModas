using BlueModas.Web.Bll;
using BlueModas.Web.Bll.Interface;
using BlueModas.Web.Dal.Interface;
using BlueModas.Web.Info.Entities;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BlueModas.Web.Test
{
    public class ProductTest
    {
        private IProductBll _productBll;
        private Mock<IProductDal> _productDal;

        [SetUp]
        public void SetUp()
        {
            _productDal = new Mock<IProductDal>();
            _productBll = new ProductBll(_productDal.Object);
        }

        [Test]
        public void ListarTodosProdutos()
        {
            var produto = new ProductInfo()
            {
                ProductId = Guid.NewGuid(),
                ProductName = "Detergente",
                Price = 10.2M,
                Quantity = 2
            };

            _productDal.Setup(x => x.GetAllProduct()).Returns(new List<ProductInfo> { produto });

            var result = _productBll.GetAllProduct();

            Assert.IsNotNull(result);
        }

        [Test]
        public void ListaProdutosNome()
        {
            var produto = new ProductInfo()
            {
                ProductId = Guid.NewGuid(),
                ProductName = "Detergente",
                Price = 10.2M,
                Quantity = 2
            };

            _productDal.Setup(x => x.GetByProductName(It.IsAny<string>())).Returns(new List<ProductInfo> { produto });

            var result = _productBll.GetByProductName(produto.ProductName);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ListaProdutosId()
        {
            var produto = new ProductInfo()
            {
                ProductId = Guid.NewGuid(),
                ProductName = "Detergente",
                Price = 10.2M,
                Quantity = 2
            };

            _productDal.Setup(x => x.GetByProductId(It.IsAny<Guid>())).Returns(produto);

            var result = _productBll.GetByProductId(produto.ProductId);

            Assert.IsNotNull(result);
        }

        [Test]
        public void IncluirProdutos()
        {
            var produto = new ProductInfo()
            {
                ProductId = Guid.NewGuid(),
                ProductName = "Detergente",
                Price = 10.2M,
                Quantity = 2
            };

            _productDal.Setup(x => x.AddProductAsync(It.IsAny<ProductInfo>())).ReturnsAsync(produto);

            var result = _productBll.AddProductAsync(produto);

            Assert.IsNotNull(result);
        }

        [Test]
        public void EditarProdutos()
        {
            var produto = new ProductInfo()
            {
                ProductId = Guid.NewGuid(),
                ProductName = "Detergente",
                Price = 10.2M,
                Quantity = 2
            };

            _productDal.Setup(x => x.EditProductAsync(It.IsAny<ProductInfo>())).ReturnsAsync(produto);

            var result = _productBll.EditProductAsync(produto.ProductId, produto);

            Assert.IsNotNull(result);
        }

        [Test]
        public void DeletarProdutos()
        {
            var produto = new ProductInfo()
            {
                ProductId = Guid.NewGuid(),
                ProductName = "Detergente",
                Price = 10.2M,
                Quantity = 2
            };

            _productDal.Setup(x => x.DeleteProduct(It.IsAny<Guid>())).Returns(produto.ProductId);

            var result = _productBll.DeleteProduct(produto.ProductId);

            Assert.IsNotNull(result);
        }
    }
}
