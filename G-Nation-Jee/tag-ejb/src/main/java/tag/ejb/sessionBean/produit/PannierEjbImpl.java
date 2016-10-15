package tag.ejb.sessionBean.produit;

import java.util.Date;
import java.util.List;

import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import tag.ejb.domain.*;

@Stateless
public class PannierEjbImpl implements IPannierLocal,IPannierRemote{

	@PersistenceContext
	private EntityManager em;
	@Override
	public User FindUser(String idUser) {
		
		User u=em.find(User.class, idUser);
		if(u==null) throw new RuntimeException("Produit Introuvable");
		return u;
	}
	
	@Override
	public Produit getProduit(Long id) {
		Produit p=em.find(Produit.class, id);
		if(p==null) throw new RuntimeException("Produit Introuvable");
		return p;
	}
	
	@Override
	public void AddPannier(User user,Long idProduit,Date date) {
	    Produit produits= getProduit(idProduit);
		Pannier cmt= new Pannier(em.merge(produits),em.merge(user), new Date());
		
		em.persist(cmt);
		
		
	}
	@SuppressWarnings("unchecked")
	@Override
	public List<Pannier> getAllPannier() {
		Query req=em.createQuery("select p from Pannier p");
		return req.getResultList();
	}
	@Override
	public List<Pannier> chercherPannier(String Id) {
		String text= "SELECT c FROM Pannier c where  c.user.Id = :Id";
		Query query= em.createQuery(text).setParameter("Id", Id);
		 List<Pannier> list = query.getResultList();
		  return list;
	}
	
	@Override
	public Pannier getPannier(Long id) {
		Pannier p=em.find(Pannier.class, id);
		if(p==null) throw new RuntimeException("Produit Introuvable");
		return p;
	}
	@Override
	public void updatePannier(Pannier p) {
		em.merge(p);
		
	}
	@Override
	public void supprimerPannier(Long idPannier, String idUser) {
		Pannier p = getPannier(idPannier);
		User u = FindUser(idUser);
		
		if (u instanceof Administrator || u.equals(p.getUser())) {
			em.remove(p);
		}else {
			throw new RuntimeException("you don't have permission");
		}
		
	}

}
