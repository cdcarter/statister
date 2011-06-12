function(doc, req) {
  mustache = require("vendor/couchapp/lib/mustache")


  return mustache.to_html(this.templates.bonus,doc)
}
