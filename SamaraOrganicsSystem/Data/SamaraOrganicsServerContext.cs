using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SamaraOrganicsSystem.Models;

namespace SamaraOrganicsSystem.Data
{
    public partial class SamaraOrganicsServerContext : DbContext
    {
        public SamaraOrganicsServerContext()
        {
        }

        public SamaraOrganicsServerContext(DbContextOptions<SamaraOrganicsServerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CloseRegister> CloseRegister { get; set; }
        public virtual DbSet<CloseRegisterInvoices> CloseRegisterInvoices { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<InvoiceCategory> InvoiceCategory { get; set; }
        public virtual DbSet<InvoiceStatus> InvoiceStatus { get; set; }
        public virtual DbSet<Invoices> Invoices { get; set; }
        public virtual DbSet<MoneyAccounts> MoneyAccounts { get; set; }
        public virtual DbSet<MoneyAccountsHistory> MoneyAccountsHistory { get; set; }
        public virtual DbSet<PaidIn> PaidIn { get; set; }
        public virtual DbSet<PaidInCloseRegister> PaidInCloseRegister { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<Phones> Phones { get; set; }
        public virtual DbSet<Salaries> Salaries { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Vendors> Vendors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CloseRegister>(entity =>
            {
                entity.ToTable("close_register");

                entity.Property(e => e.CloseRegisterId).HasColumnName("close_register_id");

                entity.Property(e => e.AmountCounted)
                    .HasColumnName("amount_counted")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.CashDiffrence)
                    .HasColumnName("cash_diffrence")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.CcDiference)
                    .HasColumnName("cc_diference")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.CloseRegisterDate)
                    .HasColumnName("close_register_date")
                    .HasColumnType("date");

                entity.Property(e => e.CreditCardMachine)
                    .HasColumnName("credit_card_machine")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.CreditCardSystem)
                    .HasColumnName("credit_card_system")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.PaidinAmount)
                    .HasColumnName("paidin_amount")
                    .HasColumnType("decimal(12, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PaidoutAmount)
                    .HasColumnName("paidout_amount")
                    .HasColumnType("decimal(12, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ScheduleFk).HasColumnName("schedule_fk");

                entity.Property(e => e.SystemAmount)
                    .HasColumnName("system_amount")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.UserFk).HasColumnName("user_fk");

                entity.HasOne(d => d.ScheduleFkNavigation)
                    .WithMany(p => p.CloseRegister)
                    .HasForeignKey(d => d.ScheduleFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_schedule");

                entity.HasOne(d => d.UserFkNavigation)
                    .WithMany(p => p.CloseRegister)
                    .HasForeignKey(d => d.UserFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_close_register");
            });

            modelBuilder.Entity<CloseRegisterInvoices>(entity =>
            {
                entity.ToTable("close_register_invoices");

                entity.Property(e => e.CloseRegisterInvoicesId).HasColumnName("close_register_invoices_id");

                entity.Property(e => e.CloseRegisterFk).HasColumnName("close_register_fk");

                entity.Property(e => e.InvoiceFk).HasColumnName("invoice_fk");

                entity.HasOne(d => d.CloseRegisterFkNavigation)
                    .WithMany(p => p.CloseRegisterInvoices)
                    .HasForeignKey(d => d.CloseRegisterFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_close_register");

                entity.HasOne(d => d.InvoiceFkNavigation)
                    .WithMany(p => p.CloseRegisterInvoices)
                    .HasForeignKey(d => d.InvoiceFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_close_register_invoices");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasColumnName("cedula")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.LastName2)
                    .IsRequired()
                    .HasColumnName("last_name2")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.PersonFk).HasColumnName("person_fk");

                entity.Property(e => e.SalaryPerHour)
                    .HasColumnName("salary_per_hour")
                    .HasColumnType("numeric(8, 2)");

                entity.HasOne(d => d.PersonFkNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.PersonFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_person_employee");
            });

            modelBuilder.Entity<InvoiceCategory>(entity =>
            {
                entity.ToTable("invoice_category");

                entity.Property(e => e.InvoiceCategoryId).HasColumnName("invoice_category_id");

                entity.Property(e => e.CategoryDescription)
                    .HasColumnName("category_description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("category_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InvoiceStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.ToTable("invoice_status");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.StatusDescription)
                    .HasColumnName("status_description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasColumnName("status_name")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Invoices>(entity =>
            {
                entity.HasKey(e => e.InvoiceId);

                entity.ToTable("invoices");

                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");

                entity.Property(e => e.FinalPayment)
                    .HasColumnName("final_payment")
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InvoiceAmount)
                    .HasColumnName("invoice_amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.InvoiceCategoryFk).HasColumnName("invoice_category_fk");

                entity.Property(e => e.InvoiceDate)
                    .HasColumnName("invoice_date")
                    .HasColumnType("date");

                entity.Property(e => e.InvoiceDescription)
                    .HasColumnName("invoice_description")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceNumber)
                    .IsRequired()
                    .HasColumnName("invoice_number")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MoneyAccountFk).HasColumnName("money_account_fk");

                entity.Property(e => e.StatusFk).HasColumnName("status_fk");

                entity.Property(e => e.VendorFk).HasColumnName("vendor_fk");

                entity.HasOne(d => d.InvoiceCategoryFkNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.InvoiceCategoryFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_invoice_category");

                entity.HasOne(d => d.MoneyAccountFkNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.MoneyAccountFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_money_account");

                entity.HasOne(d => d.StatusFkNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.StatusFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_status");

                entity.HasOne(d => d.VendorFkNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.VendorFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_vendor");
            });

            modelBuilder.Entity<MoneyAccounts>(entity =>
            {
                entity.HasKey(e => e.MoneyAccountId)
                    .HasName("PK_money_account");

                entity.ToTable("money_accounts");

                entity.Property(e => e.MoneyAccountId).HasColumnName("money_account_id");

                entity.Property(e => e.DescriptionMoneyAccount)
                    .HasColumnName("description_money_account")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GlobalAmount)
                    .HasColumnName("global_amount")
                    .HasColumnType("decimal(15, 2)");

                entity.Property(e => e.NameMoneyAccount)
                    .HasColumnName("name_money_account")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MoneyAccountsHistory>(entity =>
            {
                entity.HasKey(e => e.HistoryId);

                entity.ToTable("money_accounts_history");

                entity.Property(e => e.HistoryId).HasColumnName("history_id");

                entity.Property(e => e.AccountFk).HasColumnName("account_fk");

                entity.Property(e => e.ActualAmount)
                    .HasColumnName("actual_amount")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.HistoryDescription)
                    .IsRequired()
                    .HasColumnName("history_description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IncomeOutcome)
                    .HasColumnName("income_outcome")
                    .HasColumnType("decimal(12, 2)");

                entity.HasOne(d => d.AccountFkNavigation)
                    .WithMany(p => p.MoneyAccountsHistory)
                    .HasForeignKey(d => d.AccountFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_accounts_history");
            });

            modelBuilder.Entity<PaidIn>(entity =>
            {
                entity.ToTable("paid_in");

                entity.Property(e => e.PaidInId).HasColumnName("paid_in_id");

                entity.Property(e => e.MoneyAccountFk).HasColumnName("money_account_fk");

                entity.Property(e => e.PaidInAmount)
                    .HasColumnName("paid_in_amount")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.PaidInDate)
                    .HasColumnName("paid_in_date")
                    .HasColumnType("date");

                entity.Property(e => e.PaidInDescription)
                    .IsRequired()
                    .HasColumnName("paid_in_description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.MoneyAccountFkNavigation)
                    .WithMany(p => p.PaidIn)
                    .HasForeignKey(d => d.MoneyAccountFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_paid_in_money_account");
            });

            modelBuilder.Entity<PaidInCloseRegister>(entity =>
            {
                entity.ToTable("paid_in_close_register");

                entity.Property(e => e.PaidInCloseRegisterId).HasColumnName("paid_in_close_register_id");

                entity.Property(e => e.CloseRegisterFk).HasColumnName("close_register_fk");

                entity.Property(e => e.PaidInFk).HasColumnName("paid_in_fk");

                entity.HasOne(d => d.CloseRegisterFkNavigation)
                    .WithMany(p => p.PaidInCloseRegister)
                    .HasForeignKey(d => d.CloseRegisterFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_paid_in_money_account_close_register");

                entity.HasOne(d => d.PaidInFkNavigation)
                    .WithMany(p => p.PaidInCloseRegister)
                    .HasForeignKey(d => d.PaidInFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_paid_in_close_register");
            });

            modelBuilder.Entity<Persons>(entity =>
            {
                entity.HasKey(e => e.IdPerson);

                entity.ToTable("persons");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__persons__AB6E6164FB82A16B")
                    .IsUnique();

                entity.Property(e => e.IdPerson).HasColumnName("id_person");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PersonName)
                    .IsRequired()
                    .HasColumnName("person_name")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Phones>(entity =>
            {
                entity.HasKey(e => e.PhoneId);

                entity.ToTable("phones");

                entity.Property(e => e.PhoneId).HasColumnName("phone_id");

                entity.Property(e => e.PersonFk).HasColumnName("person_fk");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnName("phone_number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.PersonFkNavigation)
                    .WithMany(p => p.Phones)
                    .HasForeignKey(d => d.PersonFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_person_phone");
            });

            modelBuilder.Entity<Salaries>(entity =>
            {
                entity.HasKey(e => e.SalaryId);

                entity.ToTable("salaries");

                entity.Property(e => e.SalaryId).HasColumnName("salary_id");

                entity.Property(e => e.EmployeeFk).HasColumnName("employee_fk");

                entity.Property(e => e.HoursWorked)
                    .HasColumnName("hours_worked")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.InsuranceCost)
                    .HasColumnName("insurance_cost")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.MoneyAccountFk).HasColumnName("money_account_fk");

                entity.Property(e => e.SalaryAmount)
                    .HasColumnName("salary_amount")
                    .HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.EmployeeFkNavigation)
                    .WithMany(p => p.Salaries)
                    .HasForeignKey(d => d.EmployeeFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_employee_salary");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("schedule");

                entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");

                entity.Property(e => e.ScheduleName)
                    .HasColumnName("schedule_name")
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("user_role");

                entity.Property(e => e.UserRoleId).HasColumnName("user_role_id");

                entity.Property(e => e.RoleDescription)
                    .HasColumnName("role_description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnName("role_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("users");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasColumnName("password_hash")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasColumnName("password_salt")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.PersonFk).HasColumnName("person_fk");

                entity.Property(e => e.UserRoleFk).HasColumnName("user_role_fk");

                entity.HasOne(d => d.PersonFkNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PersonFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_person_user");

                entity.HasOne(d => d.UserRoleFkNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRoleFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_role");
            });

            modelBuilder.Entity<Vendors>(entity =>
            {
                entity.HasKey(e => e.VendorId);

                entity.ToTable("vendors");

                entity.Property(e => e.VendorId).HasColumnName("vendor_id");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("company_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PersonFk).HasColumnName("person_fk");

                entity.Property(e => e.VendorName)
                    .IsRequired()
                    .HasColumnName("vendor_name")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.PersonFkNavigation)
                    .WithMany(p => p.Vendors)
                    .HasForeignKey(d => d.PersonFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_person_vendor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
