namespace TAG_DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.article",
                c => new
                    {
                        idArticle = c.Int(nullable: false, identity: true),
                        DTYPE = c.String(nullable: false, maxLength: 31, storeType: "nvarchar"),
                        date = c.DateTime(precision: 0),
                        description = c.String(maxLength: 5000, storeType: "nvarchar"),
                        link_img = c.String(maxLength: 255, storeType: "nvarchar"),
                        link_imgg = c.String(maxLength: 255, storeType: "nvarchar"),
                        name = c.String(maxLength: 255, storeType: "nvarchar"),
                        adminn_idUser = c.String(maxLength: 128, storeType: "nvarchar"),
                        member_idUser = c.String(maxLength: 128, storeType: "nvarchar"),
                        media = c.Binary(),
                        idUser = c.String(maxLength: 128, storeType: "nvarchar"),
                        idVip = c.String(maxLength: 128, storeType: "nvarchar"),
                        category = c.String(unicode: false),
                        rating = c.Int(),
                        vipp_Id = c.String(maxLength: 128, storeType: "nvarchar"),
                        users_Id = c.String(maxLength: 128, storeType: "nvarchar"),
                        IsGame = c.Int(),
                        IsNews = c.Int(),
                        IsVipArticle = c.Int(),
                        IsForum = c.Int(),
                    })
                .PrimaryKey(t => t.idArticle)
                .ForeignKey("dbo.user", t => t.vipp_Id)
                .ForeignKey("dbo.user", t => t.member_idUser)
                .ForeignKey("dbo.user", t => t.idUser)
                .ForeignKey("dbo.user", t => t.adminn_idUser)
                .ForeignKey("dbo.user", t => t.idVip)
                .ForeignKey("dbo.user", t => t.users_Id)
                .Index(t => t.adminn_idUser)
                .Index(t => t.member_idUser)
                .Index(t => t.idUser)
                .Index(t => t.idVip)
                .Index(t => t.vipp_Id)
                .Index(t => t.users_Id);
            
            CreateTable(
                "dbo.commentaire",
                c => new
                    {
                        idCommentaire = c.Long(nullable: false, identity: true),
                        date = c.DateTime(precision: 0),
                        description = c.String(maxLength: 255, storeType: "nvarchar"),
                        idArticle = c.Int(),
                        idUser = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.idCommentaire)
                .ForeignKey("dbo.article", t => t.idArticle)
                .ForeignKey("dbo.user", t => t.idUser)
                .Index(t => t.idArticle)
                .Index(t => t.idUser);
            
            CreateTable(
                "dbo.user",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        socialAuth = c.Int(nullable: false),
                        HomeTown = c.String(unicode: false),
                        BirthDate = c.DateTime(precision: 0),
                        DTYPE = c.String(unicode: false),
                        firstName = c.String(unicode: false),
                        image_link = c.String(maxLength: 255, storeType: "nvarchar"),
                        lastName = c.String(unicode: false),
                        role = c.String(maxLength: 255, storeType: "nvarchar"),
                        ban = c.Boolean(nullable: false),
                        Secret = c.String(unicode: false),
                        Active = c.Boolean(nullable: false),
                        RefreshTokenLifeTime = c.Int(nullable: false),
                        AllowedOrigin = c.String(maxLength: 100, storeType: "nvarchar"),
                        Email = c.String(unicode: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(unicode: false),
                        SecurityStamp = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 0),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(unicode: false),
                        cashRecolted = c.Int(),
                        ranking = c.Int(),
                        trophies = c.Int(),
                        team_id = c.Int(),
                        team_id1 = c.Int(),
                        IsMember = c.Int(),
                        IsVip = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.team", t => t.team_id1)
                .Index(t => t.team_id1);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128, storeType: "nvarchar"),
                        ClaimType = c.String(unicode: false),
                        ClaimValue = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.user", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.commentt",
                c => new
                    {
                        date = c.DateTime(nullable: false, precision: 0),
                        idArticle = c.Int(nullable: false),
                        idUser = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        description = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.date, t.idArticle, t.idUser })
                .ForeignKey("dbo.article", t => t.idArticle, cascadeDelete: true)
                .ForeignKey("dbo.user", t => t.idUser, cascadeDelete: true)
                .Index(t => t.idArticle)
                .Index(t => t.idUser);
            
            CreateTable(
                "dbo.evenement",
                c => new
                    {
                        id_Evenement = c.Int(nullable: false, identity: true),
                        adresse = c.String(maxLength: 255, storeType: "nvarchar"),
                        date = c.DateTime(precision: 0),
                        description = c.String(maxLength: 255, storeType: "nvarchar"),
                        image_link = c.String(maxLength: 255, storeType: "nvarchar"),
                        latitude = c.String(maxLength: 255, storeType: "nvarchar"),
                        longitude = c.String(maxLength: 255, storeType: "nvarchar"),
                        name = c.String(maxLength: 255, storeType: "nvarchar"),
                        nbrPlaces = c.Int(nullable: false),
                        type = c.String(maxLength: 255, storeType: "nvarchar"),
                        organizer_idUser = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id_Evenement)
                .ForeignKey("dbo.user", t => t.organizer_idUser)
                .Index(t => t.organizer_idUser);
            
            CreateTable(
                "dbo.participants",
                c => new
                    {
                        idEvent = c.Int(nullable: false),
                        idParticipant = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        date_Limite = c.DateTime(precision: 0),
                        idEvenement = c.Int(),
                    })
                .PrimaryKey(t => new { t.idEvent, t.idParticipant })
                .ForeignKey("dbo.evenement", t => t.idEvenement)
                .ForeignKey("dbo.user", t => t.idParticipant, cascadeDelete: true)
                .Index(t => t.idParticipant)
                .Index(t => t.idEvenement);
            
            CreateTable(
                "dbo.tournament",
                c => new
                    {
                        id_tournament = c.Int(nullable: false, identity: true),
                        adresse = c.String(maxLength: 255, storeType: "nvarchar"),
                        broadcast_link = c.String(maxLength: 255, storeType: "nvarchar"),
                        description = c.String(maxLength: 255, storeType: "nvarchar"),
                        image_link = c.String(maxLength: 255, storeType: "nvarchar"),
                        latitude = c.String(maxLength: 255, storeType: "nvarchar"),
                        longitude = c.String(maxLength: 255, storeType: "nvarchar"),
                        name = c.String(maxLength: 255, storeType: "nvarchar"),
                        nbrPlaces = c.Int(nullable: false),
                        evenement_id_Evenement = c.Int(),
                        url = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id_tournament)
                .ForeignKey("dbo.evenement", t => t.evenement_id_Evenement)
                .Index(t => t.evenement_id_Evenement);
            
            CreateTable(
                "dbo.participanttournament",
                c => new
                    {
                        idEvent = c.Int(nullable: false),
                        idParticipant = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        date_limite = c.DateTime(precision: 0),
                        idTournament = c.Int(),
                    })
                .PrimaryKey(t => new { t.idEvent, t.idParticipant })
                .ForeignKey("dbo.tournament", t => t.idTournament)
                .ForeignKey("dbo.user", t => t.idParticipant, cascadeDelete: true)
                .Index(t => t.idParticipant)
                .Index(t => t.idTournament);
            
            CreateTable(
                "dbo.hardware",
                c => new
                    {
                        id_hardware = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 255, storeType: "nvarchar"),
                        reference = c.String(maxLength: 255, storeType: "nvarchar"),
                        type = c.String(maxLength: 255, storeType: "nvarchar"),
                        admin_idUser = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id_hardware)
                .ForeignKey("dbo.user", t => t.admin_idUser)
                .Index(t => t.admin_idUser);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        LoginProvider = c.String(unicode: false),
                        ProviderKey = c.String(unicode: false),
                        User_Id = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.user", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.pannier",
                c => new
                    {
                        idPannier = c.Long(nullable: false, identity: true),
                        date = c.DateTime(precision: 0),
                        idProduit = c.Long(),
                        idUser = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.idPannier)
                .ForeignKey("dbo.produit", t => t.idProduit)
                .ForeignKey("dbo.user", t => t.idUser)
                .Index(t => t.idProduit)
                .Index(t => t.idUser);
            
            CreateTable(
                "dbo.produit",
                c => new
                    {
                        idProduit = c.Long(nullable: false, identity: true),
                        date = c.DateTime(precision: 0),
                        description = c.String(maxLength: 255, storeType: "nvarchar"),
                        image_link = c.String(maxLength: 255, storeType: "nvarchar"),
                        name = c.String(maxLength: 255, storeType: "nvarchar"),
                        price = c.Double(),
                        quantite = c.Int(),
                        idUser = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.idProduit)
                .ForeignKey("dbo.user", t => t.idUser)
                .Index(t => t.idUser);
            
            CreateTable(
                "dbo.raiting",
                c => new
                    {
                        idArticle = c.Int(nullable: false),
                        idUser = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        rate = c.Int(),
                        date = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => new { t.idArticle, t.idUser })
                .ForeignKey("dbo.article", t => t.idArticle, cascadeDelete: true)
                .ForeignKey("dbo.user", t => t.idUser, cascadeDelete: true)
                .Index(t => t.idArticle)
                .Index(t => t.idUser);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        IdentityRole_Id = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.user", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .Index(t => t.UserId)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.team",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.broadcast",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        description = c.String(maxLength: 255, storeType: "nvarchar"),
                        link = c.String(maxLength: 255, storeType: "nvarchar"),
                        title = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.article", "users_Id", "dbo.user");
            DropForeignKey("dbo.article", "idVip", "dbo.user");
            DropForeignKey("dbo.article", "adminn_idUser", "dbo.user");
            DropForeignKey("dbo.article", "idUser", "dbo.user");
            DropForeignKey("dbo.article", "member_idUser", "dbo.user");
            DropForeignKey("dbo.commentaire", "idUser", "dbo.user");
            DropForeignKey("dbo.article", "vipp_Id", "dbo.user");
            DropForeignKey("dbo.user", "team_id1", "dbo.team");
            DropForeignKey("dbo.IdentityUserRoles", "UserId", "dbo.user");
            DropForeignKey("dbo.raiting", "idUser", "dbo.user");
            DropForeignKey("dbo.raiting", "idArticle", "dbo.article");
            DropForeignKey("dbo.pannier", "idUser", "dbo.user");
            DropForeignKey("dbo.pannier", "idProduit", "dbo.produit");
            DropForeignKey("dbo.produit", "idUser", "dbo.user");
            DropForeignKey("dbo.IdentityUserLogins", "User_Id", "dbo.user");
            DropForeignKey("dbo.hardware", "admin_idUser", "dbo.user");
            DropForeignKey("dbo.evenement", "organizer_idUser", "dbo.user");
            DropForeignKey("dbo.participanttournament", "idParticipant", "dbo.user");
            DropForeignKey("dbo.participanttournament", "idTournament", "dbo.tournament");
            DropForeignKey("dbo.tournament", "evenement_id_Evenement", "dbo.evenement");
            DropForeignKey("dbo.participants", "idParticipant", "dbo.user");
            DropForeignKey("dbo.participants", "idEvenement", "dbo.evenement");
            DropForeignKey("dbo.commentt", "idUser", "dbo.user");
            DropForeignKey("dbo.commentt", "idArticle", "dbo.article");
            DropForeignKey("dbo.IdentityUserClaims", "UserId", "dbo.user");
            DropForeignKey("dbo.commentaire", "idArticle", "dbo.article");
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "UserId" });
            DropIndex("dbo.raiting", new[] { "idUser" });
            DropIndex("dbo.raiting", new[] { "idArticle" });
            DropIndex("dbo.produit", new[] { "idUser" });
            DropIndex("dbo.pannier", new[] { "idUser" });
            DropIndex("dbo.pannier", new[] { "idProduit" });
            DropIndex("dbo.IdentityUserLogins", new[] { "User_Id" });
            DropIndex("dbo.hardware", new[] { "admin_idUser" });
            DropIndex("dbo.participanttournament", new[] { "idTournament" });
            DropIndex("dbo.participanttournament", new[] { "idParticipant" });
            DropIndex("dbo.tournament", new[] { "evenement_id_Evenement" });
            DropIndex("dbo.participants", new[] { "idEvenement" });
            DropIndex("dbo.participants", new[] { "idParticipant" });
            DropIndex("dbo.evenement", new[] { "organizer_idUser" });
            DropIndex("dbo.commentt", new[] { "idUser" });
            DropIndex("dbo.commentt", new[] { "idArticle" });
            DropIndex("dbo.IdentityUserClaims", new[] { "UserId" });
            DropIndex("dbo.user", new[] { "team_id1" });
            DropIndex("dbo.commentaire", new[] { "idUser" });
            DropIndex("dbo.commentaire", new[] { "idArticle" });
            DropIndex("dbo.article", new[] { "users_Id" });
            DropIndex("dbo.article", new[] { "vipp_Id" });
            DropIndex("dbo.article", new[] { "idVip" });
            DropIndex("dbo.article", new[] { "idUser" });
            DropIndex("dbo.article", new[] { "member_idUser" });
            DropIndex("dbo.article", new[] { "adminn_idUser" });
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.broadcast");
            DropTable("dbo.team");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.raiting");
            DropTable("dbo.produit");
            DropTable("dbo.pannier");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.hardware");
            DropTable("dbo.participanttournament");
            DropTable("dbo.tournament");
            DropTable("dbo.participants");
            DropTable("dbo.evenement");
            DropTable("dbo.commentt");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.user");
            DropTable("dbo.commentaire");
            DropTable("dbo.article");
        }
    }
}
