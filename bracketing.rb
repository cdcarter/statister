require 'rubygems'
require 'couchrest'
require 'enumerator'
require 'pp'
require 'json'

=begin
This is a basic script for creating whole brackets worth of rounds for a statister db.

teams:
 {"type":"team","name":"State College A", "players": ["Graham","Monica","David"]} ( TODO: alternative players: [{name:Graham,grade:12},{name:Monica,grade:11}])

brackets: 
 {type:bracket, name:"Pozzo", teams: ["State College A","Team Aweosme", "Rudy B"]} (must use exact team names as used in the teams doc)
																																									 (but this shouldn't be too hard, as this is an admin tool...)
																	
rooms:
 {type:room, number:"C112", moderator:"Bill"}
																																																										
doc:
 { teams:teams, brackets:brackets, rooms:rooms, schedules:[ {bracket:"Pozzo",room:"C112", schedule:[["state college A","team awesome"],["Rudy B","schmoop A"]]} ] }
=end

=begin
{
	"teams": [{"name":"State College A","players":["Graham","Monica"]},{"name":"Gov A","players":["Sarah","Tommy"]},{"name":"MLKA","players":["Dallas","Evan"]},{"name":"Dorman","players":["Todd","Eric"]}],
	"brackets": [{"flight":1,"name":"Pozzo","teams":["State College A","Gov A", "MLKA","Dorman"]}],
	"rooms": [{"number":1,"moderator":"Bill"},{"number":2,"moderator":"Todd"}],
	"schedules": [
		{"bracket":"Pozzo","room":1, "schedule":[["State College A", "Gov A"],["State College A","MLKA"],["State College A","Dorman"]]},
		{"bracket":"Pozzo","room":2, "schedule":[["Dorman","MLKA"],["Dorman","Gov A"],["MLKA","Gov A"]]}
	]
}
=end

class Bracketing
	def initialize(str)
		@str = str
	end
	
	def parse
		@parse ||= JSON.parse(@str)
	end

	def teams
		self.parse["teams"]
	end
	
	def room(r)
		self.parse["rooms"].find{|z| z["number"] == r }
	end
	
	def players_for_team(t)
		self.teams.find{|z| z["name"] == t}["players"] rescue puts t
	end
	
	def generate
		self.parse["schedules"].map {|s|
			base_doc = {"bracket"=>s["bracket"], "room" => s["room"], "moderator" => self.room(s["room"])["moderator"], "type"=>"game"}
			s["schedule"].enum_for(:each_with_index).map {|rs,ri|
				doc = base_doc.dup
						
				doc["teamA"] = rs[0]
			  doc["teamB"] = rs[1]
			  doc["round"] = ri+1
			  doc["teamAstats"] = self.players_for_team(rs[0]).map {|p| {"name"=>p}}
			  doc["teamBstats"] = self.players_for_team(rs[1]).map {|p| {"name"=>p}}
			
			doc
			}
		}
	end
end

if __FILE__ == $0
 pp	Bracketing.new(ARGF.read).generate
end