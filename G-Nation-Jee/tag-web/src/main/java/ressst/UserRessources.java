package ressst;

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
import tag.ejb.domain.User;
import tag.ejb.sessionBean.authenticationUserLocal;
import tag.ejb.sessionBean.registrationUserLocal;

@Path("/users")
public class UserRessources {

	@Inject
	authenticationUserLocal auth;
	@Inject
	registrationUserLocal reg;
	
	
	// get all users

	@GET
	@Produces(MediaType.APPLICATION_JSON)
	public Response getAll(){
		return Response.status(Status.OK).entity(reg.getAllUsers()).build();
	}
	// find user by id

	@GET
	@Produces("application/json")
	@Path("/member/{id}")
	public Response getUserById(@PathParam("id") String id){
		return Response
		.status(Status.OK)
        .entity(reg.findUserById(id))
        .build();	
		
	}
	// find user by username
	@GET
	@Produces("application/json")
	@Path("username")
	public Response getUserByName(@QueryParam("username") String name){
		return Response
		.status(Status.OK)
		.entity(auth.getUserByUserName(name))
        .build();	
		
	}
	
	//Registratation for a member
	@POST
	@Path("member")
	@Consumes(MediaType.APPLICATION_JSON)
	public Response Registrate(Member m){
		return Response.status(Status.OK).entity(reg.Registrate(m)).build();	
	}

	//authentication for a user
	@GET
	@Path("/{username}/{password}")
	@Produces(MediaType.APPLICATION_JSON)
   	public Response authenticate(@PathParam("username") String username ,@PathParam("password") String password){
		return Response.status(Status.OK).entity(auth.authenticateUser(username, password)).build();
		
	}
	// Update user credentials
	@PUT
	@Path("/member/{id}")
	@Consumes("application/json")
	public Response update (Member user)	
	{
		 String password = reg.encryptPassword(user.getPassword());
		user.setPassword(password);
		reg.updateUserCredentials(user);
		return Response.status(Status.OK).entity("Credentials updated").build();
	}
	
//	@PUT
//	@Path("/upp/{id}")
//		public Response update (@PathParam("id") int idUser,@QueryParam("username") String username,@QueryParam("email") String email,@QueryParam("password") String password)	
//	{    User user= reg.findUserById(idUser);
//		  password = reg.encryptPassword(user.getPassword());
//		user.setPassword(password);
//		reg.updateUserCredentials(user);
//		if (user!=null){		
//
//		return Response.status(Status.OK).entity("Credentials updated").build();
//		
//		}
//		return 	Response.status(Status.NOT_FOUND).entity("Not found").build();
//	
//	}
	
	
	
	
	// delete account
	@DELETE
	@Path("delete")
	public Response delete (@QueryParam("id") String id)
	{	User user = reg.findUserById(id);
		reg.removeUser(user);
		return Response.status(Status.OK).build();

	}
	//recover password
	@GET
	@Path("{username}")
   	public Response recoverPassword(@PathParam("username") String username){
		auth.RecoverPassword(username);
		return Response.status(Status.OK).build();
		
	}
	//recover account
	@GET
	@Path("/account/{password}")
	@Produces(MediaType.APPLICATION_JSON)
   	public Response recoverAccount(@PathParam("password") String password){
		User member = auth.RecoverAccount(password);
		if (member!=null){		
		return Response.status(Status.OK).entity(member).build();
		}
		return 	Response.status(Status.NOT_FOUND).entity("Not found").build();
	}
	//Registrate Social media
	@POST
	@Path("member/social")
	@Consumes(MediaType.APPLICATION_JSON)
	public Response RegistrateSocialMedia(Member m){
		return Response.status(Status.OK).entity(reg.RegistrateSocialMedia(m)).build();	
	}
}
