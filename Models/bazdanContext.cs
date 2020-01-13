using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CinemaAppBackend.Models
{
    public partial class bazdanContext : DbContext
    {
        public bazdanContext()
        {
        }

        public bazdanContext(DbContextOptions<bazdanContext> options)
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
        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin)
                    .HasName("PRIMARY");

                entity.ToTable("admins");

                entity.Property(e => e.IdAdmin)
                    .HasColumnName("id_admin")
                    .HasColumnType("smallint(5) unsigned");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasColumnType("mediumint(9)");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient)
                    .HasName("PRIMARY");

                entity.ToTable("clients");

                entity.Property(e => e.IdClient)
                    .HasColumnName("id_client")
                    .HasColumnType("mediumint(8) unsigned");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.Secret)
                    .IsRequired()
                    .HasColumnName("secret")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.HasKey(e => e.IdDiscount)
                    .HasName("PRIMARY");

                entity.ToTable("discounts");

                entity.Property(e => e.IdDiscount)
                    .HasColumnName("id_discount")
                    .HasColumnType("tinyint(3) unsigned")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Ammount)
                    .HasColumnName("ammount")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee)
                    .HasName("PRIMARY");

                entity.ToTable("employees");

                entity.Property(e => e.IdEmployee)
                    .HasColumnName("id_employee")
                    .HasColumnType("smallint(5) unsigned");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasColumnType("mediumint(9)");

                entity.Property(e => e.Secret)
                    .IsRequired()
                    .HasColumnName("secret")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.HasKey(e => e.IdFilm)
                    .HasName("PRIMARY");

                entity.ToTable("films");

                entity.HasIndex(e => e.IdGenre)
                    .HasName("id_genre");

                entity.HasIndex(e => e.IdImbd)
                    .HasName("id_imbd")
                    .IsUnique();

                entity.Property(e => e.IdFilm)
                    .HasColumnName("id_film")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.IdGenre)
                    .HasColumnName("id_genre")
                    .HasColumnType("smallint(5) unsigned");

                entity.Property(e => e.IdImbd)
                    .HasColumnName("id_imbd")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.GenreNavigation)
                    .WithMany(p => p.Films)
                    .HasForeignKey(d => d.IdGenre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("films_ibfk_1");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.IdGenre)
                    .HasName("PRIMARY");

                entity.ToTable("genres");

                entity.Property(e => e.IdGenre)
                    .HasColumnName("id_genre")
                    .HasColumnType("smallint(5) unsigned");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.HasKey(e => e.IdPrice)
                    .HasName("PRIMARY");

                entity.ToTable("prices");

                entity.Property(e => e.IdPrice)
                    .HasColumnName("id_price")
                    .HasColumnType("tinyint(3) unsigned")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Ammount)
                    .HasColumnName("ammount")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.IdReservation)
                    .HasName("PRIMARY");

                entity.ToTable("reservations");

                entity.HasIndex(e => e.IdClient)
                    .HasName("id_client");

                entity.HasIndex(e => e.IdTicket)
                    .HasName("id_ticket");

                entity.Property(e => e.IdReservation)
                    .HasColumnName("id_reservation")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.DateIssued)
                    .HasColumnName("date_issued")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateSubmission)
                    .HasColumnName("date_submission")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.IdClient)
                    .HasColumnName("id_client")
                    .HasColumnType("mediumint(8) unsigned");

                entity.Property(e => e.IdTicket)
                    .HasColumnName("id_ticket")
                    .HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.ClientNavigation)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.IdClient)
                    .HasConstraintName("reservations_ibfk_1");

                entity.HasOne(d => d.TicketNavigation)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.IdTicket)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reservations_ibfk_2");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.IdRoom)
                    .HasName("PRIMARY");

                entity.ToTable("rooms");

                entity.Property(e => e.IdRoom)
                    .HasColumnName("id_room")
                    .HasColumnType("tinyint(3) unsigned");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.SeatCount)
                    .HasColumnName("seat_count")
                    .HasColumnType("smallint(6)");
            });

            modelBuilder.Entity<Screening>(entity =>
            {
                entity.HasKey(e => e.IdScreening)
                    .HasName("PRIMARY");

                entity.ToTable("screenings");

                entity.HasIndex(e => e.IdFilm)
                    .HasName("id_film");

                entity.HasIndex(e => e.IdPrice)
                    .HasName("id_price");

                entity.Property(e => e.IdScreening)
                    .HasColumnName("id_screening")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.DateScreening)
                    .HasColumnName("date_screening")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdFilm)
                    .HasColumnName("id_film")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.IdPrice)
                    .HasColumnName("id_price")
                    .HasColumnType("tinyint(3) unsigned");

                entity.HasOne(d => d.FilmNavigation)
                    .WithMany(p => p.Screenings)
                    .HasForeignKey(d => d.IdFilm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("screenings_ibfk_1");

                entity.HasOne(d => d.PriceNavigation)
                    .WithMany(p => p.Screenings)
                    .HasForeignKey(d => d.IdPrice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("screenings_ibfk_2");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.IdTicket)
                    .HasName("PRIMARY");

                entity.ToTable("tickets");

                entity.HasIndex(e => e.IdDiscount)
                    .HasName("id_discount");

                entity.HasIndex(e => e.IdEmployee)
                    .HasName("id_employee");

                entity.HasIndex(e => e.IdPrice)
                    .HasName("id_price");

                entity.HasIndex(e => e.IdRoom)
                    .HasName("id_room");

                entity.HasIndex(e => e.IdScreening)
                    .HasName("id_screening");

                entity.Property(e => e.IdTicket)
                    .HasColumnName("id_ticket")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.IdDiscount)
                    .HasColumnName("id_discount")
                    .HasColumnType("tinyint(3) unsigned");

                entity.Property(e => e.IdEmployee)
                    .HasColumnName("id_employee")
                    .HasColumnType("smallint(5) unsigned");

                entity.Property(e => e.IdPrice)
                    .HasColumnName("id_price")
                    .HasColumnType("tinyint(3) unsigned");

                entity.Property(e => e.IdRoom)
                    .HasColumnName("id_room")
                    .HasColumnType("tinyint(3) unsigned");

                entity.Property(e => e.IdScreening)
                    .HasColumnName("id_screening")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.SeatNumber)
                    .HasColumnName("seat_number")
                    .HasColumnType("tinyint(4)");

                entity.HasOne(d => d.DiscountNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdDiscount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tickets_ibfk_3");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tickets_ibfk_4");

                entity.HasOne(d => d.PriceNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdPrice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tickets_ibfk_2");

                entity.HasOne(d => d.RoomNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdRoom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tickets_ibfk_1");

                entity.HasOne(d => d.ScreeningNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdScreening)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tickets_ibfk_5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
