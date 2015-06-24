using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MakeYourPartyServer.Models.EntityConfiguration
{
    public class MusicEntityConfiguration : EntityTypeConfiguration<MusicModel>
    {
        public MusicEntityConfiguration()
        {
                this.ToTable("Music");

                this.HasKey<int>(x => x.Id);

                this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

                this.HasRequired<UserModel>(x => x.User);

                this.Property(x => x.VideoId).IsRequired();

                this.Property(x => x.Title).IsOptional();

                this.Property(x => x.PartyId).IsRequired();
        }
    }
}