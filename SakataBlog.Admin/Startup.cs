using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SakataBlog.Application.Catalog.CategoryFolder;
using SakataBlog.Application.Catalog.PostFolder;
using SakataBlog.Application.Catalog.TagFolder;
using SakataBlog.Application.Common;
using SakataBlog.Application.Mappings;
using SakataBlog.Application.System.PermissionFolder;
using SakataBlog.Application.System.RoleFolder;
using SakataBlog.Application.System.UserFolder;
using SakataBlog.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SakataBlog.Admin
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();

            //Settup ket noi database
            services.AddDbContext<SakataBlogDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SakataBlogDb")));

            //Khai Bao cac Service
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ITagService, TagService>();
            services.AddTransient<IPostServcie, PostService>();
            services.AddTransient<IUserService, Userservice>();
            services.AddTransient<IPermissionService, PermissionService>();
            services.AddTransient<IRoleService, RoleService>();

            //Khai bao Service Luu tru
            services.AddTransient<IStorageService, FileStorageService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.AddAutoMapper(typeof(Startup));
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PostInTagProfile());
                mc.AddProfile(new RoleInPermissionProfile());
                mc.AddProfile(new PostInCategoryProfile());
                mc.AddProfile(new UserInRoleProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            //Setup Authentication
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(options =>
              {
                  //Neu chua dang nhap thi voa link nay
                  options.LoginPath = "/Login";
                  options.AccessDeniedPath = "/User/Forbidden/";
              });

            services.AddAuthorization(options =>
            {
                //Tag
                options.AddPolicy("CanTagIndex", policy =>
                {
                    // policy.RequireRole("Editor");
                    policy.RequireClaim("Permission", "tag.index");
                });

                options.AddPolicy("CanTagCreate", policy =>
                {
                    //Can Create 1 tag record
                    policy.RequireClaim("Permission", "tag.create");
                });
                options.AddPolicy("CanTagDetail", policy =>
                {
                    //Can detail 1 tag record
                    policy.RequireClaim("Permission", "tag.detail");
                });
                options.AddPolicy("CanTagDelete", policy =>
                {
                    //Can detail 1 tag record
                    policy.RequireClaim("Permission", "tag.delete");
                });
                options.AddPolicy("CanTagDestroy", policy =>
                {
                    //Can detail 1 tag record
                    policy.RequireClaim("Permission", "tag.destroy");
                });
                options.AddPolicy("CanTagUpdate", policy =>
                {
                    //Can detail 1 tag record
                    policy.RequireClaim("Permission", "tag.update");
                });

                //Category
                options.AddPolicy("CanCategoryIndex", policy =>
                {
                    // policy.RequireRole("Editor");
                    policy.RequireClaim("Permission", "category.index");
                });

                options.AddPolicy("CanCategoryCreate", policy =>
                {
                    //Can Create 1 tag record
                    policy.RequireClaim("Permission", "category.create");
                });
                options.AddPolicy("CanCategoryDetail", policy =>
                {
                    //Can detail 1 tag record
                    policy.RequireClaim("Permission", "category.detail");
                });
                options.AddPolicy("CanCategoryDelete", policy =>
                {
                    //Can detail 1 tag record
                    policy.RequireClaim("Permission", "category.delete");
                });
                options.AddPolicy("CanCategoryDestroy", policy =>
                {
                    //Can detail 1 tag record
                    policy.RequireClaim("Permission", "category.destroy");
                });
                options.AddPolicy("CanCategoryUpdate", policy =>
                {
                    //Can detail 1 tag record
                    policy.RequireClaim("Permission", "category.update");
                });

                //role
                options.AddPolicy("CanRoleIndex", policy =>
                {
                    // policy.RequireRole("Editor");
                    policy.RequireClaim("Permission", "role.index");
                });

                options.AddPolicy("CanRoleCreate", policy =>
                {
                    //Can Create 1 tag record
                    policy.RequireClaim("Permission", "role.create");
                });
                options.AddPolicy("CanRoleDetail", policy =>
                {
                    //Can detail 1 tag record
                    policy.RequireClaim("Permission", "role.detail");
                });
                options.AddPolicy("CanRoleDelete", policy =>
                {
                    //Can detail 1 tag record
                    policy.RequireClaim("Permission", "role.delete");
                });
                options.AddPolicy("CanRoleDestroy", policy =>
                {
                    //Can detail 1 tag record
                    policy.RequireClaim("Permission", "role.destroy");
                });
                options.AddPolicy("CanRoleUpdate", policy =>
                {
                    //Can detail 1 tag record
                    policy.RequireClaim("Permission", "role.update");
                });

                //user
                options.AddPolicy("CanUserIndex", policy =>
                {
                    // policy.RequireRole("Editor");
                    policy.RequireClaim("Permission", "user.index");
                });

                options.AddPolicy("CanUserCreate", policy =>
                {
                    //Can Create 1 tag record
                    policy.RequireClaim("Permission", "user.create");
                });
                options.AddPolicy("CanUserDetail", policy =>
                {
                    //Can detail 1 tag record
                    policy.RequireClaim("Permission", "user.detail");
                });
                options.AddPolicy("CanUserDelete", policy =>
                {
                    //Can detail 1 tag record
                    policy.RequireClaim("Permission", "user.delete");
                });
                options.AddPolicy("CanUserDestroy", policy =>
                {
                    //Can detail 1 tag record
                    policy.RequireClaim("Permission", "user.destroy");
                });
                options.AddPolicy("CanUserUpdate", policy =>
                {
                    //Can detail 1 tag record
                    policy.RequireClaim("Permission", "user.update");
                });

                //post
                options.AddPolicy("CanPostIndex", policy =>
                {
                    // policy.RequireRole("Editor");
                    policy.RequireClaim("Permission", "user.index");
                });

                options.AddPolicy("CanPostCreate", policy =>
                {
                    //Can Create 1 tag record
                    policy.RequireClaim("Permission", "user.create");
                });
                options.AddPolicy("CanPostDetail", policy =>
                {
                    //Can detail 1 tag record
                    policy.RequireClaim("Permission", "user.detail");
                });
                options.AddPolicy("CanPostDelete", policy =>
                {
                    //Can detail 1 tag record
                    policy.RequireClaim("Permission", "user.delete");
                });
                options.AddPolicy("CanPostDestroy", policy =>
                {
                    //Can detail 1 tag record
                    policy.RequireClaim("Permission", "user.destroy");
                });
                options.AddPolicy("CanPostUpdate", policy =>
                {
                    //Can detail 1 tag record
                    policy.RequireClaim("Permission", "user.update");
                });
            });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}