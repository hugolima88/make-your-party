using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MakeYourPartyServer.Models.EntityConfiguration
{
    public class InviteEntityConfiguration : EntityTypeConfiguration<InviteModel>
    {
        public InviteEntityConfiguration()
        {
                this.ToTable("Invite");

                this.HasKey<int>(x => x.Id);

                this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

                this.HasRequired<UserModel>(x => x.User);

                this.HasRequired<PartyModel>(x => x.Party).WithMany(x => x.Invites).HasForeignKey(x => x.PartyId).WillCascadeOnDelete(false);
        }
    }
}