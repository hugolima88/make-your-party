using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MakeYourPartyServer.Models.EntityConfiguration
{
    public class UserEntityConfiguration : EntityTypeConfiguration<UserModel>
    {
        public UserEntityConfiguration()
        {
                this.ToTable("User");
                
                this.HasKey<string>(x => x.Id);

                this.HasMany<PartyModel>(x => x.Parties)
                   .WithRequired(c => c.User);
        }
    }
}