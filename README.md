STATISTER
=========

Statister is (ideally) a full fledged statistics getup for some academic competition.

It runs on CouchDB.

Components (in the form of ddocs)
=================================

* "stats" -- the ddoc for entering in stats by hand, and also displaying stats.  This has near full SQBS features now.
* "gameplay" -- the module for live gameplay, creating conversion and buzz documents, and compiling game documents.
* "bracketing.rb" -- a little ruby script that will make stub game records based on a JSON input.