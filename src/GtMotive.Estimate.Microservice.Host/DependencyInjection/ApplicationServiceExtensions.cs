﻿using GtMotive.Estimate.Microservice.Api.Presenters;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAvailableVehicles;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Host.DependencyInjection
{
    /// <summary>
    /// Registers application-specific services.
    /// </summary>
    public static class ApplicationServiceExtensions
    {
        /// <summary>
        /// Adds application use cases, presenters, and repositories.
        /// </summary>
        /// <param name="services"> .</param>
        /// <returns> _.</returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUseCase<CreateVehicleInput>, CreateVehicleUseCase>();
            services.AddScoped<ICreateVehicleOutputPort, CreateVehiclePresenter>();

            services.AddScoped<CreateVehiclePresenter>();
            services.AddScoped<ICreateVehicleOutputPort>(sp => sp.GetRequiredService<CreateVehiclePresenter>());
            services.AddScoped<IUseCase<CreateVehicleInput>, CreateVehicleUseCase>();

            services.AddScoped<IUseCase<GetAvailableVehiclesInput>, GetAvailableVehiclesUseCase>();
            services.AddScoped<IGetAvailableVehiclesOutputPort>(sp => sp.GetRequiredService<GetAvailableVehiclesPresenter>());
            services.AddScoped<GetAvailableVehiclesPresenter>();

            services.AddScoped<RentVehiclePresenter>();
            services.AddScoped<IRentVehicleOutputPort>(sp => sp.GetRequiredService<RentVehiclePresenter>());
            services.AddScoped<IUseCase<RentVehicleInput>, RentVehicleUseCase>();

            services.AddScoped<ReturnVehiclePresenter>();
            services.AddScoped<IReturnVehicleOutputPort>(sp => sp.GetRequiredService<ReturnVehiclePresenter>());
            services.AddScoped<IUseCase<ReturnVehicleInput>, ReturnVehicleUseCase>();

            services.AddSingleton<IVehicleRepository, InMemoryVehicleRepository>();
            services.AddSingleton<IUnitOfWork, InMemoryUnitOfWork>();

            return services;
        }
    }
}
