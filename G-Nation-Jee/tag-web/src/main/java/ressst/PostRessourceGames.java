package ressst;

import java.util.List;

import javax.inject.Inject;
import javax.ws.rs.Consumes;
import javax.ws.rs.DELETE;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.PUT;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.QueryParam;


import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import javax.ws.rs.core.Response.Status;

import tag.ejb.domain.Member;
import tag.ejb.domain.commentt;
import tag.ejb.domain.game;
import tag.ejb.domain.news;
import tag.ejb.domain.raiting;
import tag.ejb.sessionBean.registrationUserLocal;
import tag.ejb.sessionBean.Games.gestionGamesLocal;
import tag.ejb.sessionBean.News.gestionNewsLocal;
import tag.ejb.sessionBean.user.gestionUserBeansLocal;

@Path("/Games")
public class PostRessourceGames {
	
	
	@Inject
	gestionGamesLocal myejb ;
	@Inject
	gestionUserBeansLocal gestus;
	
	@Inject
	gestionNewsLocal myejbb ;
	
	@Inject
	registrationUserLocal reg;
	
	
	
	// get All games
		@GET
		@Produces("application/json")
		@Path("/games")
		public Response getAll(){
			return Response.status(Status.OK).entity(myejb.getAllGames()).build();			
		}
	
		
		
		@GET
		@Produces("application/json")
		@Path("/Comments/{idArticle}")
		public Response getAllComments(@PathParam("idArticle") int idArticle){
			return Response.status(Status.OK).entity(myejbb.getCommentByArticle(idArticle)).build();			
		}
	
	   
		
		
		
		
		
		
	
	//find news By id
	@GET
	@Produces("application/json")
	@Path("{idArticle}")
	public Response  getGamesByID(@PathParam("idArticle") int idArticle)
	{     return Response.status(Status.OK).entity(myejb.findGamesById(idArticle)).build();	
	}
	 
	
	  
	@GET
	@Produces("application/json")
	@Path("/bestRanked")
	public Response getbestRanked(){
		return Response.status(Status.OK).entity(myejb.getBestRanked()).build();	
		
		
	}
	
	@POST
	@Path("/CommmOnGames")
	@Consumes("application/json")
	public Response CommentOnGames (@QueryParam("idArticle") int idArticle,@QueryParam("idUser") String idUser,@QueryParam("Discrip") String description)
	{ 
		Member mem= gestus.findUserById(idUser);
		myejb.CommentOnGames(mem, idArticle, description);
		return Response.status(Status.OK).build();	
		
	}
	
	@GET
	@Produces("application/json")
	@Path("/CommGamesByMemberGame")
	public Response getCommGamee(@QueryParam("idUser") String idUser,@QueryParam("idArticle") int idArticle){
		
		return Response.status(Status.OK).entity(myejb.findCommGamesByMemberNews(idUser, idArticle)).build();	
		
		
		
	}
	
	
	
	@DELETE
	@Path("/delete")
	public Response deleteComm (@QueryParam("iduser") String idUser,@QueryParam("idArticle") int idArticle)
	{	commentt cmg = myejb.findCommGamesByMemberNews(idUser, idArticle);
	        myejb.removeCommentOnGames(cmg);
	        return Response.status(Status.OK).build();	
			
	}
	
	
	
	@PUT
	@Path("/updateComm/{id}")
	@Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
	public Response update(commentt cmmm)	
	{
		myejb.updateComment(cmmm);;
		return Response.status(Status.OK).build();
	}
	
	
	
   @POST
   @Path("/RateGames")
   @Consumes("application/json")
   public Response RateGamess(@QueryParam("idUser") String idUser,@QueryParam("idArticle") int idArticle,@QueryParam("rate") int rate)
{ 
	Member mem= gestus.findUserById(idUser);
	
	
	myejb.RateGames(mem, idArticle, rate);
	
	return Response.status(Status.OK).build();	

   	
	
	
}

    @PUT
	@Path("/member/{id}")
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
	public Response update (Member user)	
	{
//		 String password = reg.encryptPassword(user.getPassword());
//		user.setPassword(password);
		reg.updateUserCredentials(user);
		return Response.status(Status.OK).entity("Credentials updated").build();
	}
   
   
   
   
   
    @DELETE
	@Path("/cancelRate")
	public Response cancelrate (@QueryParam("iduser") String idUser,@QueryParam("idArticle") int idArticle)
	{	Member u= gestus.findUserById(idUser);
	    game game=myejb.findGamesById(idArticle);
	        myejb.cancelRate(u, game);
	        return Response.status(Status.OK).build();	
			
	}
	}
   
   
   
   
   
	
   
	
	
	

