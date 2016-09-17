using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListPeople.Models {
    public class PersonRepository {

            public static List<Person> _people = new List<Person>();
            
            public void create(Person person ) {
                _people.Add(person);
            }

            public void edit(Person person ) {
                delete(person.id);
                create(person);
            }

            public void delete(int id) {
                _people.RemoveAt(_people.FindIndex(a => a.id == id));
            }

            public Person getById( int pId ) {
                return _people.Find(a => a.id == pId);
            }
        }
    }