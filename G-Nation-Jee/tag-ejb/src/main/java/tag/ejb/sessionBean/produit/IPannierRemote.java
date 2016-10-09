package tag.ejb.sessionBean.produit;


import java.util.Date;
import java.util.List;

import javax.ejb.Remote;

import tag.ejb.domain.*;


@Remote
public interface IPannierRemote {
	
	public void AddPannier(User user,Long idProduit,Date date);
	public List<Pannier> getAllPannier();
	public List<Pannier> chercherPannier(String idUser);
	public Pannier getPannier(Long id);
	public void updatePannier(Pannier p);
	public void supprimerPannier(Long idPannier,String idUser);
	public User FindUser(String id);
	public Produit getProduit(Long id);
}
