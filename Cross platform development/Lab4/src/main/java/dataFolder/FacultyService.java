package dataFolder;

import org.hibernate.annotations.SourceType;

import javax.persistence.*;
import java.util.List;

/**
 * Created by denis on 30.03.17.
 */


public class FacultyService  {
    public List<FacultyEntity> soutgetAll(){
        EntityManagerFactory em =
                Persistence.createEntityManagerFactory("NewPersistenceUnit");
        EntityManager enMan = em.createEntityManager();
        Query q= enMan.createQuery("Select p from FacultyEntity p");
        List<FacultyEntity> list = q.getResultList();
        for(FacultyEntity entity:list){
            System.out.println(entity);
        }
        return list;
    }

}