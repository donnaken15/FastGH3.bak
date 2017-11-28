#include <windows.h>
#include <tchar.h> 
#include <wctype.h>
#include <stdio.h>
#include <iostream>
#include <fstream>
#include <vector>
#include <algorithm>
#include "core.h"


std::vector<HANDLE> g_loadedPlugins;

void LoadPlugins()
{
	std::wofstream log;
	log.open("log");
	log << L"";
	


	HANDLE hFind;
	WIN32_FIND_DATA data;

	hFind = FindFirstFile(L"plugins\\*.dll", &data);

	if (hFind != INVALID_HANDLE_VALUE)
	{
		do
		{
			HANDLE plugin = LoadPlugin(data.cFileName, log);
			
			if (plugin != NULL)
			{
				g_loadedPlugins.push_back(plugin);
				
			}

		} while (FindNextFile(hFind, &data));

		FindClose(hFind);
	}

	log << L"OK";
	log.close();
}

HANDLE LoadPlugin(LPCWSTR plugin, std::wofstream &log)
{
	std::wstring plugin2(plugin);
	std::wstring lowerPlugin2(plugin);
	std::transform(lowerPlugin2.begin(), lowerPlugin2.end(), lowerPlugin2.begin(), ::towlower);

	if (lstrcmp(lowerPlugin2.c_str(), L"core.dll") == 0 || !lendswith(lowerPlugin2.c_str(), L".dll"))
		return NULL;

	std::wstring dir(L"plugins\\");
	dir.append(lowerPlugin2);
	
    HANDLE pluginHandle = LoadLibraryW(dir.c_str());
    if (pluginHandle != INVALID_HANDLE_VALUE && pluginHandle != NULL)
    {
        log << L"loaded " << dir.c_str() << " @ " << pluginHandle << L"\n";
    }
    else
    {
        log << L"failed " << dir.c_str() << L" | why: " << GetLastError() << L"\n";
    }
    return pluginHandle;
    

}


bool lendswith(LPCWSTR str, LPCWSTR ending)
{
	int length = lstrlen(str);
	int endLength = lstrlen(ending);

	if (endLength > length)
		return false;

	LPCWSTR strEnding = str + length - endLength;

	if (lstrcmp(strEnding, ending) == 0)
		return true;

	return false;
}