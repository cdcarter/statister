function(doc,req) {
	var mustache = require("vendor/couchapp/lib/mustache")
  var ddoc = this;
	var resp
		
	doc.moderator = req.form.moderator

	doc.teamAscore = parseInt(req.form.teamAscore)
	doc.teamBscore = parseInt(req.form.teamBscore)
	
	doc.teamAtuh = parseInt(req.form.teamAtuh)
	doc.teamBtuh = parseInt(req.form.teamBtuh)
	
	doc.teamAbhrd = parseInt(req.form.teamAbhrd)
	doc.teamBbhrd = parseInt(req.form.teamBbhrd)

	doc.teamAbpts = parseInt(req.form.teamAbpts)
	doc.teamBbpts = parseInt(req.form.teamBbpts)
	
	for (var i in doc.teamAstats) {
		doc.teamAstats[i].tens = parseInt(req.form["teamA"+i+"tens"])
		doc.teamAstats[i].negs = parseInt(req.form["teamA"+i+"negs"])
		doc.teamAstats[i].tuh = parseInt(req.form["teamA"+i+"tuh"])
	}
	
	for (var i in doc.teamBstats) {
		doc.teamBstats[i].tens = parseInt(req.form["teamB"+i+"tens"])
		doc.teamBstats[i].negs = parseInt(req.form["teamB"+i+"negs"])
		doc.teamBstats[i].tuh = parseInt(req.form["teamB"+i+"tuh"])
	}
	
	resp = '<html><title>redirect</title><body><a href="../../_show/game_entry/'+doc._id+'">Click Here</a></body></html>'
	
	return [doc,resp]
}