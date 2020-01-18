using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CinemaAppBackend.Models
{
    public partial class dbContext : DbContext
    {
        public dbContext()
        {
        }

        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Screening> Screenings { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admins");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.PhoneNumber).HasColumnType("decimal(11,0)");

                entity.Property(e => e.Salary).HasColumnType("int(11)");

                entity.Property(e => e.Secret)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("clients");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.PhoneNumber).HasColumnType("decimal(11,0)");

                entity.Property(e => e.Secret)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.ToTable("discounts");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Ammount).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.PhoneNumber).HasColumnType("decimal(11,0)");

                entity.Property(e => e.Salary).HasColumnType("int(11)");

                entity.Property(e => e.Secret)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.ToTable("films");

                entity.HasIndex(e => e.GenreId)
                    .HasName("GenreId");

                entity.HasIndex(e => e.ImdbId)
                    .HasName("ImdbId")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.GenreId).HasColumnType("int(11)");

                entity.Property(e => e.ImdbId)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Films)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("films_ibfk_1");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genres");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.ToTable("prices");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Ammount).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("reservations");

                entity.HasIndex(e => e.ClientId)
                    .HasName("ClientId");

                entity.HasIndex(e => e.TicketId)
                    .HasName("TicketId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClientId).HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.SubmissionDate).HasColumnType("datetime");

                entity.Property(e => e.TicketId).HasColumnType("int(11)");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("reservations_ibfk_1");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.TicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reservations_ibfk_2");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("rooms");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.SeatCount).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Screening>(entity =>
            {
                entity.ToTable("screenings");

                entity.HasIndex(e => e.FilmId)
                    .HasName("FilmId");

                entity.HasIndex(e => e.PriceId)
                    .HasName("PriceId");

                entity.HasIndex(e => e.RoomId)
                    .HasName("RoomId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.FilmId).HasColumnType("int(11)");

                entity.Property(e => e.PriceId).HasColumnType("int(11)");

                entity.Property(e => e.RoomId).HasColumnType("int(11)");

                entity.Property(e => e.ScreeningDate).HasColumnType("datetime");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.Screenings)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("screenings_ibfk_1");

                entity.HasOne(d => d.Price)
                    .WithMany(p => p.Screenings)
                    .HasForeignKey(d => d.PriceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("screenings_ibfk_2");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Screenings)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("screenings_ibfk_3");
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.ToTable("seats");

                entity.HasIndex(e => e.RoomId)
                    .HasName("RoomId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.RoomId).HasColumnType("int(11)");

                entity.Property(e => e.Rowing).HasColumnType("int(11)");

                entity.Property(e => e.SeatNumber).HasColumnType("int(11)");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Seats)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("seats_ibfk_1");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("tickets");

                entity.HasIndex(e => e.DiscountId)
                    .HasName("DiscountId");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("EmployeeId");

                entity.HasIndex(e => e.ScreeningId)
                    .HasName("ScreeningId");

                entity.HasIndex(e => e.SeatId)
                    .HasName("SeatId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DiscountId).HasColumnType("int(11)");

                entity.Property(e => e.EmployeeId).HasColumnType("int(11)");

                entity.Property(e => e.IssuedDate).HasColumnType("datetime");

                entity.Property(e => e.ScreeningId).HasColumnType("int(11)");

                entity.Property(e => e.SeatId).HasColumnType("int(11)");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.DiscountId)
                    .HasConstraintName("tickets_ibfk_1");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("tickets_ibfk_2");

                entity.HasOne(d => d.Screening)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.ScreeningId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tickets_ibfk_3");

                entity.HasOne(d => d.Seat)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.SeatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tickets_ibfk_4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
