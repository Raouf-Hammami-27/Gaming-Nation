package ressst;

import javax.inject.Inject;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.Response;
import javax.ws.rs.core.Response.Status;

import tag.ejb.sessionBean.gestionBroadcastLocal;


@Path("/broadcast")
public class BroadcastResource {

		@Inject
		gestionBroadcastLocal myBroadcast;
		
		@GET
		@Produces("application/json")
		public Response getAll(){

			return Response.status(Status.OK).entity(myBroadcast.getAllBroadcast()).build();
		}
		
}
