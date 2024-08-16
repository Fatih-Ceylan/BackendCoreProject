using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Platform.Domain.Entities.Definitions;
using Platform.Domain.Entities.Definitions.Files;
using Platform.Domain.Entities.Identity;
using System.Security.Claims;
using Utilities.Core.UtilityDomain.Entities;
using Utilities.Core.UtilityDomain.Entities.Files;

namespace Platform.Persistence.Contexts
{
    public class PlatformDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        readonly IHttpContextAccessor _httpContextAccessor;

        public PlatformDbContext(DbContextOptions<PlatformDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        #region Definitions
        public DbSet<Company> Companies { get; set; }

        public DbSet<License> Licenses { get; set; }

        public DbSet<LicenseType> LicenseTypes { get; set; }

        public DbSet<GModule> GModules { get; set; }

        public DbSet<LicenseDetail> LicenseDetails { get; set; }

        public DbSet<SpecialOffer> SpecialOffers { get; set; }

        public DbSet<GModuleLicenseTypePrice> GModuleLicenseTypePrices { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        #region Files
        public DbSet<AppFile> AppFiles { get; set; }

        public DbSet<CompanyFile> CompanyFiles { get; set; }

        public DbSet<GModuleFile> GModuleFiles { get; set; }
        #endregion

        #endregion

        public async Task<string> GetCurrentNameIdentifierAsync()
        {
            return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Company>()
                   .HasIndex(c => new { c.BaseDbName, c.UrlPath })
                   .IsUnique();

            base.OnModelCreating(builder);

            //builder.Entity<GModule>().HasData(Configuration.GModules);
            //builder.Entity<LicenseType>().HasData(Configuration.LicenseTypes);
            //builder.Entity<GModuleLicenseTypePrice>().HasData(Configuration.GModuleLicenseTypePrices);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.PlatformConnectionString);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            #region Tüm entitylerde ortak değişiklikler
            //ChangeTracker entitiy üzerinde yapılan değişiklikleri yakalar.


            var datas = ChangeTracker.Entries<BaseEntity>(); //tip base entitiy olarak giren tüm modelleri yakala


            foreach (var data in datas)
            {
                switch (data.State)
                {
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        if (data.Entity.IsDeleted)
                        {
                            data.Entity.DeletedBy = await GetCurrentNameIdentifierAsync();
                            data.Entity.DeletedDate = DateTime.Now;
                        }
                        else
                        {
                            data.Entity.UpdatedBy = await GetCurrentNameIdentifierAsync();
                            data.Entity.UpdatedDate = DateTime.Now;
                        }
                        break;
                    case EntityState.Added:
                        data.Entity.CreatedBy = await GetCurrentNameIdentifierAsync() ?? "user none";
                        data.Entity.CreatedDate = DateTime.Now;
                        break;
                    default:
                        break;
                }
            }
            #endregion

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}