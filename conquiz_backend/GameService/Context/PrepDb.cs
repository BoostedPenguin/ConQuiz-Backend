﻿using GameService.Grpc;
using GameService.Models;
using GameService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameService.Context
{
    public static class PrepDb
    {
        public static void PrepMigration(IApplicationBuilder app, bool isProd)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var contextFactory = serviceScope.ServiceProvider.GetService<IDbContextFactory<DefaultContext>>();
            
            if (true)
            {
                ApplyMigrations(contextFactory);
            }

            ValidateResources(
                serviceScope.ServiceProvider.GetService<IMapGeneratorService>(),
                serviceScope.ServiceProvider.GetService<IGameService>(),
                serviceScope.ServiceProvider.GetService<IQuestionService>());

            Console.WriteLine("--> Database prepared!");

            var grpcClient = serviceScope.ServiceProvider.GetService<IAccountDataClient>();

            var users = grpcClient.ReturnAllAccounts();

            if (users == null) return;
            FetchAccounts(contextFactory, users);
        }

        private static void FetchAccounts(IDbContextFactory<DefaultContext> contextFactory, IEnumerable<Users> users)
        {
            Console.WriteLine("Applying missing users...");

            using var db = contextFactory.CreateDbContext();

            foreach(var user in users)
            {
                if(db.Users.FirstOrDefault(x => x.ExternalId == user.ExternalId) == null)
                {
                    db.Users.Add(user);
                }
            }
            db.SaveChanges();
        }

        private static void ApplyMigrations(IDbContextFactory<DefaultContext> contextFactory)
        {
            Console.WriteLine("--> Attempting to apply migrations...");
            try
            {
                using var context = contextFactory.CreateDbContext();

                context.Database.Migrate();

                Console.WriteLine("--> Migrations added");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not run migrations: {ex.Message}");
            }
        }

        private static void ValidateResources(IMapGeneratorService mapGeneratorService, IGameService gameService, IQuestionService questionService)
        {
            try
            {
                // Validate map
                mapGeneratorService.ValidateMap();

                // Cancel all "stuck" games
                gameService.CancelOngoingGames();

                // Validate questions
                //questionService.AddDefaultQuestions();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"--> Could not validate resources: {ex.Message}");
            }
        }
    }
}
