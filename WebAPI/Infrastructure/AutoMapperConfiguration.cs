﻿using AutoMapper;
using Service.Product.Model;
using WebApi.Models.Product;

namespace WebApi.Infrastructure
{
    public static class AutoMapperConfiguration
    {
        private static MapperConfiguration _mapperConfiguration;
        private static IMapper _mapper;

        /// <summary>
        /// Initialize mapper
        /// </summary> 
        public static void Init()
        {
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDtoEditModel, ProductEditModel>().ReverseMap();
                cfg.CreateMap<ProductDtoSearchModel, ProductSearchModel>().ReverseMap();      
                cfg.CreateMap<ProductDtoViewModel, ProductGridModel>().ReverseMap();
            });
            _mapper = _mapperConfiguration.CreateMapper();
        }

        /// <summary>
        /// Mapper
        /// </summary>
        public static IMapper Mapper
        {
            get
            {
                return _mapper;
            }
        }
        /// <summary>
        /// Mapper configuration
        /// </summary>
        public static MapperConfiguration MapperConfiguration
        {
            get
            {
                return _mapperConfiguration;
            }
        }
    }
}
