namespace TortenKreationSHS.Repositories {

    using System.Collections.Generic;
    using TortenKreationSHS.Models;

    public interface ICakeRepository {

        List<Cake> GetAll();
        Cake GetBySlug(string slug);

    }

}