using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListPeople.Models {
    public class CarRepository {

            public static List<Car> _car = new List<Car>();

            public void create(Car car) {
                _car.Add(car);
            }

            public void edit(Car car) {
                delete(car.id);
                create(car);
            }

            public void delete(int id) {
                _car.RemoveAt(_car.FindIndex(a => a.id == id));
            }

            public Car getById(int id ) {
                return _car.Find(a => a.id == id);
            }
        }
    }