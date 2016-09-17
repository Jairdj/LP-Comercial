using Associations.Conections;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Associations.Models {
    public class MemberRepository {

        FioTerra fioTerra;

        public MemberRepository() {
            fioTerra = new FioTerra();
        }

        public void Create (Member member ) {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            sql.Append("INSERT into members(name) ");
            sql.Append("values (@name)");

            cmm.Parameters.AddWithValue("@name", member.name);
            cmm.CommandText = sql.ToString();

            fioTerra.ExecuteCommand(cmm);
        }

        public List<Member> getAll() {

            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();
            List<Member> members = new List<Member>();
            //String de comando sql
            sql.Append("SELECT * from members order by id asc");
            //Converte a string em comando
            cmm.CommandText = sql.ToString();
            //Executa o comando e armazena a tabela na var dr
            MySqlDataReader dr = fioTerra.GetDataReader(cmm);


            while( dr.Read() ) {
                members.Add(new Member {
                    id = (int)dr["id"],
                    name = dr["name"].ToString()    
                });
            } 
            return members;
        }

        public Member getById( int pId ) {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();
            Member pMember = new Member();

            // cuidado com as 'aspas simples'
            // ps: fazedora de café dormiu!! :( 
            sql.Append("SELECT name FROM members WHERE id = @id ");

            cmm.Parameters.AddWithValue("@id", pId);
            cmm.CommandText = sql.ToString();
            MySqlDataReader dr = fioTerra.GetDataReader(cmm);

            //não alterar
            //sério
            while( dr.Read() ) {
                pMember = new Member {
                    id = pId,
                    name = dr["name"].ToString()
                    };
                }
            return pMember;
            }

        public void Edit(Member member ) {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            sql.Append("UPDATE members SET name = @name where members.id = @id");

            cmm.Parameters.AddWithValue("@name", member.name);
            cmm.Parameters.AddWithValue("@id", member.id);
            cmm.CommandText = sql.ToString();

            fioTerra.ExecuteCommand(cmm);
        }

        public void Delete(int id ) {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            sql.Append("DELETE FROM members where id = @id");
            
            cmm.Parameters.AddWithValue("@id", id);
            cmm.CommandText = sql.ToString();

            fioTerra.ExecuteCommand(cmm);
            }
    }
}