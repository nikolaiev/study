package dataFolder;

import javax.persistence.*;

/**
 * Created by denis on 28.03.17.
 */
@Entity
@Table(name = "faculty", schema = "public", catalog = "postgres")
public class FacultyEntity {
    private long facultyId;
    private String name;

    @Id
    @Column(name = "faculty_id")
    public long getFacultyId() {
        return facultyId;
    }

    public void setFacultyId(long facultyId) {
        this.facultyId = facultyId;
    }

    @Basic
    @Column(name = "name")
    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        FacultyEntity that = (FacultyEntity) o;

        if (facultyId != that.facultyId) return false;
        if (name != null ? !name.equals(that.name) : that.name != null) return false;

        return true;
    }

    @Override
    public int hashCode() {
        int result = (int) (facultyId ^ (facultyId >>> 32));
        result = 31 * result + (name != null ? name.hashCode() : 0);
        return result;
    }
}
