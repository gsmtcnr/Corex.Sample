using Corex.Data.Derived.EntityFramework;
using Corex.Model.Derived.EntityModel;
using Corex.Sample.Core.Infrastructure;
using Corex.Sample.Model.EntityModel;
using Corex.Sample.Model.EntityModel.Orders.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Reflection;


namespace Corex.Sample.Data.Derived.EFSQL
{
    public class CorexDBContext : BaseEntityContext
    {
        public CorexDBContext() : base(GetOptions())
        {
        }
        private static string GetConnectionString()
        {
            string connectionString = string.Empty;
            if (!IoCManager.IsInstalled)
            {
                if (!IoCManager.IsInstalled)
                    new CorexStartup();
            }
            IConfigurationRoot configuration = IoCManager.Resolve<IConfigurationRoot>();
            connectionString = configuration.GetConnectionString("DbSQL");
            return connectionString;
        }
        public static DbContextOptions<CorexDBContext> GetOptions()
        {
            DbContextOptionsBuilder<CorexDBContext> optionsBuilder = new DbContextOptionsBuilder<CorexDBContext>();
            optionsBuilder.UseSqlServer(GetConnectionString());
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            return optionsBuilder.Options;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            MethodInfo entityMethod = modelBuilder.GetType().GetTypeInfo().GetMethods().First(p => p.Name == nameof(ModelBuilder.Entity) && p.IsGenericMethod);
            foreach (IEntityTypeConfiguration item in IoCManager.ResolveAll<IEntityTypeConfiguration>())
            {
                TypeInfo typeInfo = item.GetType().GetTypeInfo();
                System.Type baseType = item.GetType().BaseType;
                MethodInfo mapMethod = GetMapMethod(typeInfo, baseType);
                TypeInfo baseTypeInfo = typeInfo.BaseType.GetTypeInfo();
                System.Type entityGenericType = baseTypeInfo.GenericTypeArguments[0];
                MethodInfo genericMethod = entityMethod.MakeGenericMethod(entityGenericType);
                object methodResult = genericMethod.Invoke(modelBuilder, null);
                mapMethod.Invoke(item, new object[] { methodResult });
            }
        }
        private static MethodInfo GetMapMethod(TypeInfo typeInfo, Type baseType)
        {
            MethodInfo mapMethod = null;
            string entityGuidType = typeof(CorexBaseEntityGuidConfiguration<BaseCorexEntityGuidModel>).Name;
            string entityIntType = typeof(CorexBaseEntityIntConfiguration<BaseCorexEntityIntModel>).Name;
            string baseTypeName = baseType.Name;
            if (baseTypeName == entityGuidType)
                mapMethod = typeInfo.GetMethod(nameof(CorexBaseEntityGuidConfiguration<BaseCorexEntityGuidModel>.Map));
            else if (baseTypeName == entityIntType)
                mapMethod = typeInfo.GetMethod(nameof(CorexBaseEntityIntConfiguration<BaseCorexEntityIntModel>.Map));
            return mapMethod;
        }
    }
}
