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
		var _lenA = doc.teamAstats.length
		for (var i=0; i<_lenA; ++i ) {
			doc.teamAstats[i].idx = i
		}
		var _lenB = doc.teamBstats.length
		for (var i=0; i<_lenB; ++i ) {
			doc.teamBstats[i].idx = i
		}
	} else {
		doc = {}
		doc._root = ".."
	}

	return mustache.to_html(ddoc.templates.entry,doc)
}