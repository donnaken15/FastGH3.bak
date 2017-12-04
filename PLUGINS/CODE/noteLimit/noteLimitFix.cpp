#include "noteLimitFix.h"
#include "core\Patcher.h"
#include <stdint.h>

const uint32_t MAX_NOTES 5162;//5DA666
const uint32_t GH3_MAX_PLAYERS = 2;
void* const SIZEOP_NOTE_ALLOCATION = (void*)0x0041AA78;
void* const ADDROP_SUSTAINARRAY_1 = (void*)0x0041EE33;
void * const ADDROP_SUSTAINARRAY_2 = (void*)0x00423CD4;
void * const ADDROP_SUSTAINARRAY_3 = (void*)0x00423D02;
void * const ADDROP_FCARRAY = (void*)0x00423D14;
void * const ADDROP_NOTEOFFSETARRAY = (void*)0x00423D22;


static float* fixedSustainArray = nullptr;
static float* fixedFcArray = nullptr;
static uint32_t* fixedOffsetArray = nullptr;


static GH3P::Patcher g_patcher = GH3P::Patcher(__FILE__);


void FixNoteLimit()
{
if(fixedSustainArray == nullptr)
fixedSustainArray = new float[MAX_NOTES * GH3_MAX_PLAYERS];


if(fixedFcArray == nullptr)
fixedFcArray = new float[MAX_NOTES * GH3_MAX_PLAYERS];

if(fixedOffsetArray == nullptr)
fixedOffsetArray = new uint32_t[MAX_NOTES * GH3_MAX_PLAYERS];


g_patcher.WriteInt32(SIZEOP_NOTE_ALLOCATION, MAX_NOTES);

g_patcher.WriteInt32(ADDROP_SUSTAINARRAY_1, reinterpret_cast<uint32_t>(fixedSustainArray));
g_patcher.WriteInt32(ADDROP_SUSTAINARRAY_2, reinterpret_cast<uint32_t>(fixedSustainArray));
g_patcher.WriteInt32(ADDROP_SUSTAINARRAY_3, reinterpret_cast<uint32_t>(fixedSustainArray));
g_patcher.WriteInt32(ADDROP_FCARRAY, reinterpret_cast<uint32_t>(fixedFcArray));
g_patcher.WriteInt32(ADDROP_NOTEOFFSETARRAY, reinterpret_cast<uint32_t>(fixedOffsetArray));
}

