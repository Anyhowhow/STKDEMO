import urllib
import urllib.request


def httpDownload(url, filename):
    request = urllib.request.Request(url)
    while True:
        try:
            response = urllib.request.urlopen(request)
        except Exception as e:
            print('Connect filed , re-connect....')
            continue
        break

    get_file = response.read()
    with open(filename, 'wb') as fp:
        fp.write(get_file)
        print(filename + ' download completed')
    return


# #get the source ip address
# address_Url = 'http://192.168.100.127/E%3A/%E4%BB%BB%E5%8A%A1%E8%A7%84%E5%88%92%E7%AB%AF1.0.4/TaskPlanning/TaskPlanning/bin/Debug/path.csv'
# file_local_name =  'path.csv'
# httpDownload(address_Url, file_local_name)