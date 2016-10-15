package tag.ejb.sessionBean.produit;

import java.util.List;

import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import tag.ejb.domain.*;



@Stateless
public  class ProduitEjbImpl implements IProduitLocal,IProduitRemote {
   
	@PersistenceContext
	private EntityManager em;

	@Override
	public User FindUser(String idUser) {
		
		User u=em.find(User.class, idUser);
		if(u==null) throw new RuntimeException("User Introuvable");
		return u;
	}
	
	@Override
	public String AddProduit(Produit p) {
			em.persist(p);
			return "ok";
		}

	@SuppressWarnings("unchecked")
	@Override
	public List<Produit> getAllProduit() {
		Query req=em.createQuery("select p from Produit p");
		return req.getResultList();
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Produit> chercherProduit(String m) {
		try {
			Query req=em.createQuery("select p from Produit p where p.name like ?1");
			req.setParameter(1, "%"+ m +"%");
			return req.getResultList();
		} catch (Exception e) {
			// TODO Auto-generated catch block
			throw new RuntimeException("Product not Found");
		}
	}

	@Override
	public Produit getProduit(Long id) {
		Produit p=em.find(Produit.class, id);
		if(p==null) throw new RuntimeException("Produit Introuvable");
		return p;
	}

	@Override
	public void updateProduit(Produit p) {
		em.merge(p);
		
	}

	@Override
	public void supprimerProduit(Long idProduit,String idUser) {
		
		Produit p = getProduit(idProduit);
		User u = FindUser(idUser);
		
		if (p.getUser().equals(u)) {
			em.remove(p);
		}else {
			throw new RuntimeException("you don't have permission");
		}
		
	}

}
