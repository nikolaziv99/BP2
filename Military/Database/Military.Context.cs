﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Military.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MilitaryContainer : DbContext
    {
        public MilitaryContainer()
            : base("name=MilitaryContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Specialty> Specialties { get; set; }
        public virtual DbSet<Camp> Camps { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<Examination> Examinations { get; set; }
        public virtual DbSet<Rank> Ranks { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<MilitaryPerson> MilitaryPersons { get; set; }
        public virtual DbSet<Soldier> Soldiers { get; set; }
        public virtual DbSet<Medic> Medics { get; set; }
    }
}
