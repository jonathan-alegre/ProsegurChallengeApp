using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using ProsegurChallengeApp.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using ProsegurChallengeApp.Models;

public class Program
{
    public static async Task Main( string[] args )
    {
        var builder = WebApplication.CreateBuilder( args );

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers(
            options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true );

        builder.Services.AddDbContext<CafeteriaDbContext>();

        builder.Services.AddIdentity<IdentityUser, IdentityRole>( options => options.SignIn.RequireConfirmedAccount = true ).AddUserStore<DbContext>();

        builder.Services.AddAuthentication( CookieAuthenticationDefaults.AuthenticationScheme ).AddCookie(
            options => options.LoginPath = "/Cuenta/Login"
        );

        var app = builder.Build();

        if ( app.Environment.IsDevelopment() )
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // Configure the HTTP request pipeline.
        if ( !app.Environment.IsDevelopment() )
        {
            app.UseExceptionHandler( "/Error" );
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();

        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapRazorPages();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}" );

        using ( var scope = app.Services.CreateScope() )
        {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roles = new[] { "Usuario", "Empleado", "Supervisor", "Administrador" };

            foreach ( var rol in roles )
            {
                if ( !await roleManager.RoleExistsAsync( rol ) )
                {
                    await roleManager.CreateAsync( new IdentityRole( rol ) );
                    Usuario usuario = new Usuario();                    
                }
            }
        }

        app.Run();
    }

}