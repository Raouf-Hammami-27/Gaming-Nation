package tag.ejb.sessionBean.vip;

import java.util.List;

import javax.ejb.Local;

import tag.ejb.domain.*;


@Local
public interface IVipArticleLocal {

	public String AddVipArticle(VipArticle v);
	public List<VipArticle> getAllVipArticle();
	public List<VipArticle> chercherVipArticle(String idVip);
	public VipArticle getVipArticle(Integer id);
	public void updateVipArticle(VipArticle v);
	public void supprimerVipArticle(Integer idVipArticle,String idUser);
	public User FindUser(String id);
	public List<Commentaire> getCommentaire(Long id);
}
