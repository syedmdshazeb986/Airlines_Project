﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airlines_API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<UserDetails> UserDetails { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<FlightModel> Flights { get; set; }

        public DbSet<Flight> AddFlights { get; set; }

        public DbSet<Airport> Airports { get; set; }

        public DbSet<Seat> GetSeatsByFId { get; set; }

        public DbSet<BookingData> GettingBookingData { get; set; }
        public DbSet<GetBookings> GetBookings { get; set; }
        public DbSet<Price> price { get; set; }
        public DbSet<SearchData> FilteredFlights { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
    }
}
