function(doc, req) {
  mustache = require("vendor/couchapp/lib/mustache")

	data = {"number":doc.number,"answer":doc.answer,"words":[]}
  words = doc.text.split(" ")
  for (idx in words) {
    data.words.push({"number":idx,"word":words[idx]})
  }

  return mustache.to_html(this.templates.tossup,data)
}
