function(doc,req) {
	var mustache = require("vendor/couchapp/lib/mustache")
  var ddoc = this;

	if (doc) {
		doc._root = "../.."
		
		// gonna make a dangerous assumption here that if teamA doesn't have a TUH value, the round hasn't been entered
		if (!doc.teamAtuh) {
			doc.teamAtuh = 20;
			doc.teamBtuh = 20;
		}
		for (var i in doc.teamAstats) {
			doc.teamAstats[i].idx = i
		}
		for (var i in doc.teamBstats) {
			doc.teamBstats[i].idx = i
		}
	} else {
		doc = {}
		doc._root = ".."
	}

	return mustache.to_html(ddoc.templates.entry,doc)
}