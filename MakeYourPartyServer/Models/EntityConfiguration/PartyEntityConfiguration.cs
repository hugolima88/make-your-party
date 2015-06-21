using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MakeYourPartyServer.Models.EntityConfiguration
{
    public class PartyEntityConfiguration : EntityTypeConfiguration<PartyModel>
    {
        public PartyEntityConfiguration()
        {
                this.ToTable("Party");
                
                this.HasKey<int>(x => x.Id);

                this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

                this.Property(x => x.Password).IsRequired();
        }
    }
}