﻿using AutoMapper;
using PointOfSale.Model;
using PointOfSale.Models;
using System.Globalization;


namespace PointOfSale.Utilities.Automapper
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{

			#region Rol
			CreateMap<Rol, VMRol>().ReverseMap();
			#endregion

			#region User
			CreateMap<User, VMUser>()
			.ForMember(destiny =>
				destiny.IsActive,
				opt => opt.MapFrom(source => source.IsActive == true ? 1 : 0)
			)
			.ForMember(destiny =>
				destiny.NameRol,
				opt => opt.MapFrom(source => source.IdRolNavigation.Description)
			).ForMember(destiny =>
				destiny.PhotoBase64,
				opt => opt.MapFrom(source => Convert.ToBase64String(source.Photo))
			)
			.ForMember(destiny =>
				destiny.Photo,
				opt => opt.Ignore()
			);

			CreateMap<VMUser, User>()
			.ForMember(destiny =>
				destiny.IsActive,
				opt => opt.MapFrom(source => source.IsActive == 1 ? true : false)
			)
			.ForMember(destiny =>
				destiny.IdRolNavigation,
				opt => opt.Ignore()
			);
			#endregion

			#region Category
			CreateMap<Category, VMCategory>()
			.ForMember(destiny =>
				destiny.IsActive,
				opt => opt.MapFrom(source => source.IsActive == true ? 1 : 0)
			);

			CreateMap<VMCategory, Category>()
			.ForMember(destiny =>
				destiny.IsActive,
				opt => opt.MapFrom(source => source.IsActive == 1 ? true : false)
			);
			#endregion

			#region Bank
			CreateMap<Bank, VMBank>()
			.ForMember(destiny =>
				destiny.IsActive,
				opt => opt.MapFrom(source => source.IsActive == true ? 1 : 0)
			);

			CreateMap<VMBank, Bank>()
			.ForMember(destiny =>
				destiny.IsActive,
				opt => opt.MapFrom(source => source.IsActive == 1 ? true : false)
			);
			#endregion

			#region Size
			CreateMap<Size, VMSize>()
			.ForMember(destiny =>
				destiny.IsActive,
				opt => opt.MapFrom(source => source.IsActive == true ? 1 : 0)
			);

			CreateMap<VMSize, Size>()
			.ForMember(destiny =>
				destiny.IsActive,
				opt => opt.MapFrom(source => source.IsActive == 1 ? true : false)
			);
			#endregion

			#region Design
			CreateMap<Design, VMDesign>()
			.ForMember(destiny =>
				destiny.IsActive,
				opt => opt.MapFrom(source => source.IsActive == true ? 1 : 0)
			);

			CreateMap<VMDesign, Design>()
			.ForMember(destiny =>
				destiny.IsActive,
				opt => opt.MapFrom(source => source.IsActive == 1 ? true : false)
			);
			#endregion

			#region Artical
			CreateMap<Artical, VMArtical>()
			.ForMember(destiny =>
				destiny.IsActive,
				opt => opt.MapFrom(source => source.IsActive == true ? 1 : 0)
			);

			CreateMap<VMArtical, Artical>()
			.ForMember(destiny =>
				destiny.IsActive,
				opt => opt.MapFrom(source => source.IsActive == 1 ? true : false)
			);
			#endregion

			#region Colour
			CreateMap<Colour, VMColour>()
			.ForMember(destiny =>
				destiny.IsActive,
				opt => opt.MapFrom(source => source.IsActive == true ? 1 : 0)
			);

			CreateMap<VMColour, Colour>()
			.ForMember(destiny =>
				destiny.IsActive,
				opt => opt.MapFrom(source => source.IsActive == 1 ? true : false)
			);
			#endregion

			#region Style
			CreateMap<Style, VMStyle>()
			.ForMember(destiny =>
				destiny.IsActive,
				opt => opt.MapFrom(source => source.IsActive == true ? 1 : 0)
			);

			CreateMap<VMStyle, Style>()
			.ForMember(destiny =>
				destiny.IsActive,
				opt => opt.MapFrom(source => source.IsActive == 1 ? true : false)
			);
			#endregion


			//#region Customer
			//CreateMap<Customer, VMCustomer>()
			//.ForMember(destiny =>
			//	destiny.IsActive,
			//	opt => opt.MapFrom(source => source.IsActive == true ? 1 : 0)
			//)

			//.ForMember(destiny =>
			//	destiny.PhotoBase64,
			//	opt => opt.MapFrom(source => Convert.ToBase64String(source.Photo))
			//);

			//CreateMap<VMCustomer, Customer>()
			//.ForMember(destiny =>
			//	destiny.IsActive,
			//	opt => opt.MapFrom(source => source.IsActive == 1 ? true : false)
			//);
			//#endregion

			#region Customer
			CreateMap<Customer, VMCustomer>()
			.ForMember(destiny =>
				destiny.IsActive,
				opt => opt.MapFrom(source => source.IsActive == true ? 1 : 0)
			)
			//.ForMember(destiny =>
			//	destiny.NameCategory,
			//	opt => opt.MapFrom(source => source.IdCategory)
			//)

			.ForMember(destiny =>
				destiny.NameCategory,
				opt => opt.MapFrom(source => source.IdCategoryNavigation.Description)
			)
			//.ForMember(destiny =>
			//	destiny.Price,
			//	opt => opt.MapFrom(source => Convert.ToString(source.Price, new CultureInfo("es-PE")))
			//)
			//.ForMember(destiny =>
			//	destiny.OpeningBalance,
			//	opt => opt.MapFrom(source => Convert.ToString(source.OpeningBalance, new CultureInfo("es-PE")))
			//)
			.ForMember(destiny =>
				destiny.PhotoBase64,
				opt => opt.MapFrom(source => Convert.ToBase64String(source.Photo))
			);

			CreateMap<VMCustomer, Customer>()
			.ForMember(destiny =>
				destiny.IsActive,
				opt => opt.MapFrom(source => source.IsActive == 1 ? true : false)
			).ForMember(destiny =>
				destiny.IdCategoryNavigation,
				opt => opt.Ignore()
			);
			//.ForMember(destiny =>
			//	destiny.IdCategory,
			//	opt => opt.Ignore()
			//)
			//.ForMember(destiono =>
			//	destiono.Price,
			//	opt => opt.MapFrom(source => Convert.ToString(source.Price, new CultureInfo("es-PE")))
			//)
			//.ForMember(destiny =>
			//	destiny.OpeningBalance,
			//	opt => opt.MapFrom(source => Convert.ToString(source.OpeningBalance, new CultureInfo("es-PE")))
			//);
			#endregion


			#region GatePass
			CreateMap<GatePass, VMGatePass>();

			//.ForMember(destiny =>
			//	destiny.NameCategory,
			//	opt => opt.MapFrom(source => source.IdCategory)
			//)


			//.ForMember(destiny =>
			//	destiny.Price,
			//	opt => opt.MapFrom(source => Convert.ToString(source.Price, new CultureInfo("es-PE")))
			//)
			//.ForMember(destiny =>
			//	destiny.OpeningBalance,
			//	opt => opt.MapFrom(source => Convert.ToString(source.OpeningBalance, new CultureInfo("es-PE")))
			//)


			CreateMap<VMGatePass, GatePass>();
			
			//.ForMember(destiny =>
			//	destiny.IdCategory,
			//	opt => opt.Ignore()
			//)
			//.ForMember(destiono =>
			//	destiono.Price,
			//	opt => opt.MapFrom(source => Convert.ToString(source.Price, new CultureInfo("es-PE")))
			//)
			//.ForMember(destiny =>
			//	destiny.OpeningBalance,
			//	opt => opt.MapFrom(source => Convert.ToString(source.OpeningBalance, new CultureInfo("es-PE")))
			//);
			#endregion


			#region Product
			CreateMap<Product, VMProduct>()
			.ForMember(destiny =>
				destiny.IsActive,
				opt => opt.MapFrom(source => source.IsActive == true ? 1 : 0)
			)
			.ForMember(destiny =>
				destiny.NameCategory,
				opt => opt.MapFrom(source => source.IdCategoryNavigation.Description)
			)
			.ForMember(destiny =>
				destiny.Price,
				opt => opt.MapFrom(source => Convert.ToString(source.Price.Value, new CultureInfo("es-PE")))
			)
			.ForMember(destiny =>
				destiny.WSPrice,
				opt => opt.MapFrom(source => Convert.ToString(source.WSPrice.Value, new CultureInfo("es-PE")))
			)
			.ForMember(destiny =>
				destiny.PhotoBase64,
				opt => opt.MapFrom(source => Convert.ToBase64String(source.Photo))
			);

			CreateMap<VMProduct, Product>()
			.ForMember(destiny =>
				destiny.IsActive,
				opt => opt.MapFrom(source => source.IsActive == 1 ? true : false)
			)
			.ForMember(destiny =>
				destiny.IdCategoryNavigation,
				opt => opt.Ignore()
			)
			.ForMember(destiono =>
				destiono.Price,
				opt => opt.MapFrom(source => Convert.ToDecimal(source.Price, new CultureInfo("es-PE")))
			)
			.ForMember(destiny =>
				destiny.WSPrice,
				opt => opt.MapFrom(source => Convert.ToString(source.WSPrice, new CultureInfo("es-PE")))
			);
			#endregion

			#region TypeDocumentSale
			CreateMap<TypeDocumentSale, VMTypeDocumentSale>().ReverseMap();
			#endregion

			#region Sale
			CreateMap<Sale, VMSale>()
				.ForMember(destiny =>
					destiny.TypeDocumentSale,
					opt => opt.MapFrom(source => source.IdTypeDocumentSaleNavigation.Description)
				)
				.ForMember(destiny =>
					destiny.Users,
					opt => opt.MapFrom(source => source.IdUsersNavigation.Name)
				)
				.ForMember(destiny =>
					destiny.Subtotal,
					opt => opt.MapFrom(source => Convert.ToString(source.Subtotal.Value, new CultureInfo("es-PE")))
				)
				.ForMember(destiny =>
					destiny.TotalTaxes,
					opt => opt.MapFrom(source => Convert.ToString(source.TotalTaxes.Value, new CultureInfo("es-PE")))
				)
				.ForMember(destiny =>
					destiny.Total,
					opt => opt.MapFrom(source => Convert.ToString(source.Total.Value, new CultureInfo("es-PE")))
				).ForMember(destiny =>
					destiny.RegistrationDate,
					opt => opt.MapFrom(source => source.RegistrationDate.Value.ToString("dd/MM/yyyy"))
				);

			CreateMap<VMSale, Sale>()
				.ForMember(destiny =>
					destiny.Subtotal,
					opt => opt.MapFrom(source => Convert.ToDecimal(source.Subtotal, new CultureInfo("es-PE")))
				)
				.ForMember(destiny =>
					destiny.TotalTaxes,
					opt => opt.MapFrom(source => Convert.ToDecimal(source.TotalTaxes, new CultureInfo("es-PE")))
				)
				.ForMember(destiny =>
					destiny.Total,
					opt => opt.MapFrom(source => Convert.ToDecimal(source.Total, new CultureInfo("es-PE")))
				);
			#endregion

			#region DetailSale
			CreateMap<DetailSale, VMDetailSale>()
				.ForMember(destiny =>
					destiny.Price,
					opt => opt.MapFrom(source => Convert.ToString(source.Price.Value, new CultureInfo("es-PE")))
				)
				.ForMember(destiny =>
					destiny.Total,
					opt => opt.MapFrom(source => Convert.ToString(source.Total.Value, new CultureInfo("es-PE")))
				);

			CreateMap<VMDetailSale, DetailSale>()
				.ForMember(destiny =>
					destiny.Price,
					opt => opt.MapFrom(source => Convert.ToDecimal(source.Price, new CultureInfo("es-PE")))
				)
				.ForMember(destiny =>
					destiny.Total,
					opt => opt.MapFrom(source => Convert.ToDecimal(source.Total, new CultureInfo("es-PE")))
				);

			CreateMap<DetailSale, VMSalesReport>()
				.ForMember(destiny =>
					destiny.RegistrationDate,
					opt => opt.MapFrom(source => source.IdSaleNavigation.RegistrationDate.Value.ToString("dd/MM/yyyy"))
				)
				.ForMember(destiny =>
					destiny.SaleNumber,
					opt => opt.MapFrom(source => source.IdSaleNavigation.SaleNumber)
				)
				.ForMember(destiny =>
					destiny.DocumentType,
					opt => opt.MapFrom(source => source.IdSaleNavigation.IdTypeDocumentSaleNavigation.Description)
				)
				.ForMember(destiny =>
					destiny.DocumentClient,
					opt => opt.MapFrom(source => source.IdSaleNavigation.CustomerDocument)
				)
				.ForMember(destiny =>
					destiny.ClientName,
					opt => opt.MapFrom(source => source.IdSaleNavigation.ClientName)
				)
				.ForMember(destiny =>
					destiny.SubTotalSale,
					opt => opt.MapFrom(source => Convert.ToString(source.IdSaleNavigation.Subtotal.Value, new CultureInfo("es-PE")))
				)
				.ForMember(destiny =>
					destiny.TaxTotalSale,
					opt => opt.MapFrom(source => Convert.ToString(source.IdSaleNavigation.TotalTaxes.Value, new CultureInfo("es-PE")))
				)
				.ForMember(destiny =>
					destiny.TotalSale,
					opt => opt.MapFrom(source => Convert.ToString(source.IdSaleNavigation.Total.Value, new CultureInfo("es-PE")))
				)
				.ForMember(destiny =>
					destiny.Product,
					opt => opt.MapFrom(source => source.DescriptionProduct)
				)
				.ForMember(destiny =>
					destiny.Price,
					opt => opt.MapFrom(source => Convert.ToString(source.Price.Value, new CultureInfo("es-PE")))
				)
				.ForMember(destiny =>
					destiny.Total,
					opt => opt.MapFrom(source => Convert.ToString(source.Total.Value, new CultureInfo("es-PE")))
				);

			CreateMap<DetailSale, VMGatePassReport>()
				.ForMember(destiny =>
					destiny.RegistrationDate,
					opt => opt.MapFrom(source => source.IdSaleNavigation.RegistrationDate.Value.ToString("dd/MM/yyyy"))
				)
				.ForMember(destiny =>
					destiny.SaleNumber,
					opt => opt.MapFrom(source => source.IdSaleNavigation.SaleNumber)
				)
				.ForMember(destiny =>
					destiny.DocumentType,
					opt => opt.MapFrom(source => source.IdSaleNavigation.IdTypeDocumentSaleNavigation.Description)
				)
				.ForMember(destiny =>
					destiny.DocumentClient,
					opt => opt.MapFrom(source => source.IdSaleNavigation.CustomerDocument)
				)
				.ForMember(destiny =>
					destiny.ClientName,
					opt => opt.MapFrom(source => source.IdSaleNavigation.ClientName)
				)
				.ForMember(destiny =>
					destiny.SubTotalSale,
					opt => opt.MapFrom(source => Convert.ToString(source.IdSaleNavigation.Subtotal.Value, new CultureInfo("es-PE")))
				)
				.ForMember(destiny =>
					destiny.TaxTotalSale,
					opt => opt.MapFrom(source => Convert.ToString(source.IdSaleNavigation.TotalTaxes.Value, new CultureInfo("es-PE")))
				)
				.ForMember(destiny =>
					destiny.TotalSale,
					opt => opt.MapFrom(source => Convert.ToString(source.IdSaleNavigation.Total.Value, new CultureInfo("es-PE")))
				)
				.ForMember(destiny =>
					destiny.Product,
					opt => opt.MapFrom(source => source.DescriptionProduct)
				)
				.ForMember(destiny =>
					destiny.Price,
					opt => opt.MapFrom(source => Convert.ToString(source.Price.Value, new CultureInfo("es-PE")))
				)
				.ForMember(destiny =>
					destiny.Total,
					opt => opt.MapFrom(source => Convert.ToString(source.Total.Value, new CultureInfo("es-PE")))
				);
			#endregion

			#region Menu
			CreateMap<Menu, VMMenu>()
				.ForMember(destiny =>
				destiny.SubMenus,
				opt => opt.MapFrom(source => source.InverseIdMenuParentNavigation));
			#endregion Menu
		}
	}
}
