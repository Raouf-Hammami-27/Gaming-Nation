package ressst;

import java.util.Date;
import java.util.List;

import javax.inject.Inject;
import javax.ws.rs.BeanParam;
import javax.ws.rs.Consumes;
import javax.ws.rs.DELETE;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.PUT;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.QueryParam;


import javax.ws.rs.core.Response;
import javax.ws.rs.core.Response.Status;

import tag.ejb.domain.Member;
import tag.ejb.domain.User;
import tag.ejb.domain.commentt;
import tag.ejb.domain.news;
import tag.ejb.sessionBean.Games.gestionGamesLocal;
import tag.ejb.sessionBean.News.gestionNewsLocal;
import tag.ejb.sessionBean.user.gestionUserBeansLocal;



@Path("/News")
public class PostRessourceNews {

	@Inject
	gestionNewsLocal gest;
	

	
	@Inject
	gestionUserBeansLocal gestu;
	
	
	
	
	@GET
	@Produces("application/json")
	public Response getAll(){
		return Response.status(Status.OK).entity(gest.getAllNews()).build();			
	}
	
	
	
	
	@GET
	@Produces("application/json")
	@Path("/CommentsNews/{idArticle}")
	public Response getAllComments(@PathParam("idArticle") int idArticle){
		return Response.status(Status.OK).entity(gest.getCommentByArticle(idArticle)).build();			
	}

	
	
	
	
	//find News By ID 
	@GET
	@Produces("application/json")
	@Path("/news/{id}")
	public Response getNewsByID(@PathParam("id") int id)
	{     
			return Response.status(Status.OK).entity(gest.findNewsById(id)).build();	
			
		
	}
/*	//find commentaire par news et member
	@GET
	@Produces("application/json")
	@Path("/commNews")
	public Response  getCommNewsByMemberNews(@QueryParam("idUser") int idUser,@QueryParam("idArticle") int idArticle)
	{
	
		return Response.status(Status.OK).entity(gest.findCommNewsByMemberNews(idUser, idArticle)).build();	
		
	}*/
	 
	/*@GET
	@Produces("application/json")
	@Path("/commNewsss")
	public commentt  getCommNewssByMemberNews(@QueryParam("iduser") int idUser,@QueryParam("idArticle") int idArticle)
	{
		commentt cm= gest.findCommNewsByMemberNews(idUser, idArticle);
		return cm;
		
	}
	*/
	
	@PUT
	@Path("/edit")
	@Produces("application/json")
	public Response UpdateComm(commentt cm)
	{  
		
    
			gest.updateCommentOnNews(cm);
			return Response.status(Status.OK).build();	
		
		
		
	}
	
	
	@POST
	@Path("/Commentaire")
	@Consumes("application/json")
	public Response Commentonnews(@QueryParam("idArticle") int idArticle,@QueryParam("idUser") String idUser,@QueryParam("description") String description){
		
		Member user= gestu.findUserById(idUser);
		
		gest.CommentOnNews(user, idArticle,description);		
		return Response.status(Status.OK).build();	
		
	}
	
	/*@POST
	@Path("/Commen")
	@Consumes("application/json")
	public String Commentonnews(CommentNews cm){
		
		
		
		
		gest.CommentOnNews(cm);
		 return "Success";
		
	}*/
	
	
	
	
	//delete comment
	@DELETE
	@Path("/delete")
	public Response delete (@QueryParam("iduser") String idUser,@QueryParam("idArticle") int idArticle,@QueryParam("date") Date date)
	{	commentt cm = gest.findCommNewsByMemberNews(idUser, idArticle,date);
			gest.removeCommentOnNews(cm);
			return Response.status(Status.OK).build();	
			
	}
	
	
	
	
	@GET
	@Path("/MostCommented")
	@Produces("application/json")
	public Response getmostCommentes(){
		return Response.status(Status.OK).entity( gest.getMostCommented()).build();		
		
		
	}
	
	
	
}
