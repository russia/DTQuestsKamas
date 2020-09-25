import cloudscraper
import sys
import os
import json

try:
    version = str(sys.argv[1])
    if not os.path.exists('data'):
    	os.makedirs('data')
    scraper = cloudscraper.create_scraper(
	    browser={
            'browser': 'chrome',
            'platform': 'android',
            'desktop': False
        },
        cipherSuite=[
    		"ECDHE-ECDSA-AES128-GCM-SHA256",
            "ECDHE-RSA-AES128-GCM-SHA256",
            "ECDHE-RSA-AES128-SHA",
            "AES128-GCM-SHA256",
    		
    		"TLS_AES_128_GCM_SHA256",
            "TLS_AES_256_GCM_SHA384",
            "TLS_CHACHA20_POLY1305_SHA256",
            "ECDHE-ECDSA-AES256-GCM-SHA384",
            "ECDHE-RSA-AES256-GCM-SHA384",
            "ECDHE-ECDSA-CHACHA20-POLY1305",
            "ECDHE-RSA-CHACHA20-POLY1305",
            "ECDHE-RSA-AES256-SHA",
    
            "AES256-GCM-SHA384",
            "AES128-SHA",
            "AES256-SHA",
            "DES-CBC3-SHA"
        ])
    headers = {'origin': 'file://'}
    scraper.headers.update(headers)
    classes = ["Quests", "QuestSteps"]
    for c in classes:
    	js = scraper.post("https://proxyconnection.touch.dofus.com/data/map?lang=fr&v=" + version, json={'class': c, 'ids': []}, timeout=5).text
    	fpath = c[0].upper()+c[1:]+".json"
    	if os.path.exists(fpath):
    		os.remove(fpath)
    	f= open(fpath,"w+", encoding='utf8')
    	f.write(js)
    	f.close()
except Exception as e:
	print(e)
finally:
 	sys.stdout.flush()