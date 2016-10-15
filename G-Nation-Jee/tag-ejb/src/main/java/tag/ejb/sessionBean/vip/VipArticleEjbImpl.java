package tag.ejb.sessionBean.vip;

import java.util.Date;
import java.util.List;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import tag.ejb.domain.*;



@Stateless
public  class VipArticleEjbImpl implements IVipArticleLocal{
   
	@PersistenceContext
	private EntityManager em;

	@Override
	public User FindUser(String idUser) {
		
		User u=em.find(User.class, idUser);
		if(u==null) throw new RuntimeException("User Introuvable");
		return u;
	}

	@Override
	public String AddVipArticle(VipArticle v) {
		v.setDate(new Date());
		em.persist(v);
		return "ok"; 
		
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<VipArticle> getAllVipArticle() {
		Query req=em.createQuery("select v from VipArticle v");
		return req.getResultList();
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<VipArticle> chercherVipArticle(String Id) {
		try {
			Query req=em.createQuery("select v from VipArticle v where v.vip.Id = ?1");
			req.setParameter(1,Id);
			return req.getResultList();
		} catch (Exception e) {
			// TODO Auto-generated catch block
			throw new RuntimeException("VipArticle not Found");
		}
	}

	@Override
	public VipArticle getVipArticle(Integer id) {
		VipArticle v=em.find(VipArticle.class, id);
		if(v==null) throw new RuntimeException("VipArticle Introuvable");
		return v;
	}

	@Override
	public void updateVipArticle(VipArticle v) {
		em.merge(v);
		
	}

	@Override
	public void supprimerVipArticle(Integer idVipArticle, String idUser) {
		VipArticle v = getVipArticle(idVipArticle);
		User u = FindUser(idUser);
		
		if (v.getVip().equals(u)) {
			em.remove(v);
		}else {
			throw new RuntimeException("you don't have permission");
		}
		
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Commentaire> getCommentaire(Long id) {
		Query req=em.createQuery("select c from Commentaire c where c.article = ?1");
		req.setParameter(1, "%"+ id +"%");
		return req.getResultList();
	}



	
}
