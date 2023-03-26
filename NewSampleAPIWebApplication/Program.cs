using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text;
using System.Xml.Linq;
using WebApplication16.DB;

namespace WebApplication16
{
    public class car
    {

        public int id { get; set; }

        public string name { get; set; }
    }
    public class Auth
    {
        public string Handler { get; set; }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(s =>
            {
                s.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                s.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                s.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }
            
           
                ).AddJwtBearer(s =>
            {
                var key = System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]);

                s.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer= true,
                    ValidateAudience=true,
                    ValidateLifetime=true,
                    ValidIssuer = builder.Configuration["Jwt:issuer"],
                    ValidAudience= builder.Configuration["Jwt:aud"],
                    IssuerSigningKey =new SymmetricSecurityKey(key)

                };
            });

            builder.Services.AddScoped<ICarsRespoitory, CarRespoitory>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //
            var app = builder.Build();
            //call api from console
            app.MapGet("/msg", () => "hi ");
            app.MapGet("/msg/{txt}", IResult (string txt) =>
            {
                return Results.Ok($"say hi to:{txt}");
            });
            app.MapPost("/msg", ([FromHeader] int id) => $"id={id}");
            //
            app.MapPost("/msglst", IResult (List<car>lst)=> {
            
                return Results.Ok($"count={lst.Count}");
                    
            });
            //
            app.MapPost("/auth", ([FromHeader]string username, [FromHeader] string password,IConfiguration conf) =>
            {
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(conf["Jwt:Key"]));
                var jwt = new JwtSecurityToken(conf["Jwt:issuer"],
                    conf["Jwt:aud"],
                    null, null, DateTime.Now.AddDays(1),
                    new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
                //
                var hand = new JwtSecurityTokenHandler().WriteToken(jwt);
                //
                return Results.Ok(new Auth() { Handler = hand});
            });
            app.MapGet("/newAuth", () => "test auth").RequireAuthorization();

            if (app.Environment.IsDevelopment())
            {
               app.UseDeveloperExceptionPage();
               app.UseSwagger();
               app.UseSwaggerUI();
                
            }

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();



        }
        //public static  void Main(string[] args)
        //{

        //    var builder = WebApplication.CreateBuilder(args);
        //    builder.Services.AddControllers();
        //    //
        //    var app = builder.Build();


        //    ////
        //    //app.MapGet("/", () => "test").RequireAuthorization();
        //    //app.MapGet("/ToDo", async (IDB db) => db.GetAll());
        //    //app.MapGet("/ToDo/{id}", async (int id,IDB db) =>(await db.Find(id)) );
        //    //app.MapPost("/ToDo", (test t, IDB db) => db.Add(t));
        //    //app.MapPut("/ToDo/{id}", (int id,test t, IDB db) => db.Edit(t));
        //    //app.MapDelete("/ToDo/{id}", (int id, IDB db)=>db.Delete(id));

        //    //app.MapGet("/", async (IDB db) => await db.GetAll());
        //    //app.MapPut("/edit", async (int i,string name,IDB db) =>
        //    //{
        //    //    var it=await db.Edit(new test() { id=i,name=name});

        //    //    Results.Ok();
        //    //});
        //    //app.MapDelete("/delete", async (int id,IDB db) =>{
        //    //   var it= await db.Delete(id);
        //    //    Results.Ok();
        //    //});
        //    //app.MapPost("/post", async (int i, string name, IDB db) =>
        //    //{
        //    //    await db.Add(new test() { id = i, name = name });
        //    //    Results.Ok();
        //    //});
        //    app.UseRouting();
        //    app.UseHttpsRedirection();

        //    app.MapControllers();
        //    app.Run();
        //    //// Add services to the container.
        //    //builder.Services.AddRazorPages();

        //    //var app = builder.Build();

        //    //// Configure the HTTP request pipeline.
        //    //if (!app.Environment.IsDevelopment())
        //    //{
        //    //    app.UseExceptionHandler("/Error");
        //    //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        //    //    app.UseHsts();
        //    //}

        //    //app.UseHttpsRedirection();
        //    //app.UseStaticFiles();

        //    //app.UseRouting();

        //    //app.UseAuthorization();

        //    //app.MapRazorPages();

        //    //app.Run();
        //}
    }
  
}