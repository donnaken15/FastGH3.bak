; Listing generated by Microsoft (R) Optimizing Compiler Version 19.00.24215.1 

	TITLE	C:\Windows\fastgh3\PLUGINS\CODE\core\ScopedUnprotect.cpp
	.686P
	.XMM
	include listing.inc
	.model	flat

INCLUDELIB LIBCMTD
INCLUDELIB OLDNAMES

PUBLIC	??0ScopedUnprotect@GH3P@@QAE@XZ			; GH3P::ScopedUnprotect::ScopedUnprotect
PUBLIC	??0ScopedUnprotect@GH3P@@QAE@PAXK@Z		; GH3P::ScopedUnprotect::ScopedUnprotect
PUBLIC	??1ScopedUnprotect@GH3P@@QAE@XZ			; GH3P::ScopedUnprotect::~ScopedUnprotect
PUBLIC	??4ScopedUnprotect@GH3P@@QAEAAV01@ABV01@@Z	; GH3P::ScopedUnprotect::operator=
EXTRN	__imp__VirtualProtect@16:PROC
EXTRN	__RTC_CheckEsp:PROC
EXTRN	__RTC_InitBase:PROC
EXTRN	__RTC_Shutdown:PROC
;	COMDAT rtc$TMZ
rtc$TMZ	SEGMENT
__RTC_Shutdown.rtc$TMZ DD FLAT:__RTC_Shutdown
rtc$TMZ	ENDS
;	COMDAT rtc$IMZ
rtc$IMZ	SEGMENT
__RTC_InitBase.rtc$IMZ DD FLAT:__RTC_InitBase
rtc$IMZ	ENDS
; Function compile flags: /Odtp /RTCsu /ZI
;	COMDAT ??4ScopedUnprotect@GH3P@@QAEAAV01@ABV01@@Z
_TEXT	SEGMENT
_this$ = -8						; size = 4
___that$ = 8						; size = 4
??4ScopedUnprotect@GH3P@@QAEAAV01@ABV01@@Z PROC		; GH3P::ScopedUnprotect::operator=, COMDAT
; _this$ = ecx
	push	ebp
	mov	ebp, esp
	sub	esp, 204				; 000000ccH
	push	ebx
	push	esi
	push	edi
	push	ecx
	lea	edi, DWORD PTR [ebp-204]
	mov	ecx, 51					; 00000033H
	mov	eax, -858993460				; ccccccccH
	rep stosd
	pop	ecx
	mov	DWORD PTR _this$[ebp], ecx
	mov	eax, DWORD PTR ___that$[ebp]
	mov	ecx, DWORD PTR _this$[ebp]
	mov	edx, DWORD PTR [eax]
	mov	DWORD PTR [ecx], edx
	mov	edx, DWORD PTR [eax+4]
	mov	DWORD PTR [ecx+4], edx
	mov	eax, DWORD PTR [eax+8]
	mov	DWORD PTR [ecx+8], eax
	mov	eax, DWORD PTR _this$[ebp]
	pop	edi
	pop	esi
	pop	ebx
	mov	esp, ebp
	pop	ebp
	ret	4
??4ScopedUnprotect@GH3P@@QAEAAV01@ABV01@@Z ENDP		; GH3P::ScopedUnprotect::operator=
_TEXT	ENDS
; Function compile flags: /Odtp /RTCsu /ZI
; File c:\windows\fastgh3\plugins\code\core\scopedunprotect.cpp
;	COMDAT ??1ScopedUnprotect@GH3P@@QAE@XZ
_TEXT	SEGMENT
_this$ = -8						; size = 4
??1ScopedUnprotect@GH3P@@QAE@XZ PROC			; GH3P::ScopedUnprotect::~ScopedUnprotect, COMDAT
; _this$ = ecx

; 19   :     {

	push	ebp
	mov	ebp, esp
	sub	esp, 204				; 000000ccH
	push	ebx
	push	esi
	push	edi
	push	ecx
	lea	edi, DWORD PTR [ebp-204]
	mov	ecx, 51					; 00000033H
	mov	eax, -858993460				; ccccccccH
	rep stosd
	pop	ecx
	mov	DWORD PTR _this$[ebp], ecx

; 20   :         VirtualProtect(addr_, length_, oldProtect_, &oldProtect_);

	mov	eax, DWORD PTR _this$[ebp]
	mov	esi, esp
	push	eax
	mov	ecx, DWORD PTR _this$[ebp]
	mov	edx, DWORD PTR [ecx]
	push	edx
	mov	eax, DWORD PTR _this$[ebp]
	mov	ecx, DWORD PTR [eax+8]
	push	ecx
	mov	edx, DWORD PTR _this$[ebp]
	mov	eax, DWORD PTR [edx+4]
	push	eax
	call	DWORD PTR __imp__VirtualProtect@16
	cmp	esi, esp
	call	__RTC_CheckEsp

; 21   :     }

	pop	edi
	pop	esi
	pop	ebx
	add	esp, 204				; 000000ccH
	cmp	ebp, esp
	call	__RTC_CheckEsp
	mov	esp, ebp
	pop	ebp
	ret	0
??1ScopedUnprotect@GH3P@@QAE@XZ ENDP			; GH3P::ScopedUnprotect::~ScopedUnprotect
_TEXT	ENDS
; Function compile flags: /Odtp /RTCsu /ZI
; File c:\windows\fastgh3\plugins\code\core\scopedunprotect.cpp
;	COMDAT ??0ScopedUnprotect@GH3P@@QAE@PAXK@Z
_TEXT	SEGMENT
_this$ = -8						; size = 4
_addr$ = 8						; size = 4
_length$ = 12						; size = 4
??0ScopedUnprotect@GH3P@@QAE@PAXK@Z PROC		; GH3P::ScopedUnprotect::ScopedUnprotect, COMDAT
; _this$ = ecx

; 14   :     {

	push	ebp
	mov	ebp, esp
	sub	esp, 204				; 000000ccH
	push	ebx
	push	esi
	push	edi
	push	ecx
	lea	edi, DWORD PTR [ebp-204]
	mov	ecx, 51					; 00000033H
	mov	eax, -858993460				; ccccccccH
	rep stosd
	pop	ecx
	mov	DWORD PTR _this$[ebp], ecx

; 13   :     ScopedUnprotect::ScopedUnprotect(LPVOID addr, SIZE_T length) : addr_(addr), length_(length)

	mov	eax, DWORD PTR _this$[ebp]
	mov	ecx, DWORD PTR _addr$[ebp]
	mov	DWORD PTR [eax+4], ecx
	mov	eax, DWORD PTR _this$[ebp]
	mov	ecx, DWORD PTR _length$[ebp]
	mov	DWORD PTR [eax+8], ecx

; 15   :         VirtualProtect(addr_, length_, PAGE_EXECUTE_READWRITE, &oldProtect_);

	mov	eax, DWORD PTR _this$[ebp]
	mov	esi, esp
	push	eax
	push	64					; 00000040H
	mov	ecx, DWORD PTR _this$[ebp]
	mov	edx, DWORD PTR [ecx+8]
	push	edx
	mov	eax, DWORD PTR _this$[ebp]
	mov	ecx, DWORD PTR [eax+4]
	push	ecx
	call	DWORD PTR __imp__VirtualProtect@16
	cmp	esi, esp
	call	__RTC_CheckEsp

; 16   :     }

	mov	eax, DWORD PTR _this$[ebp]
	pop	edi
	pop	esi
	pop	ebx
	add	esp, 204				; 000000ccH
	cmp	ebp, esp
	call	__RTC_CheckEsp
	mov	esp, ebp
	pop	ebp
	ret	8
??0ScopedUnprotect@GH3P@@QAE@PAXK@Z ENDP		; GH3P::ScopedUnprotect::ScopedUnprotect
_TEXT	ENDS
; Function compile flags: /Odtp /RTCsu /ZI
; File c:\windows\fastgh3\plugins\code\core\scopedunprotect.cpp
;	COMDAT ??0ScopedUnprotect@GH3P@@QAE@XZ
_TEXT	SEGMENT
_this$ = -8						; size = 4
??0ScopedUnprotect@GH3P@@QAE@XZ PROC			; GH3P::ScopedUnprotect::ScopedUnprotect, COMDAT
; _this$ = ecx

; 10   :     {

	push	ebp
	mov	ebp, esp
	sub	esp, 204				; 000000ccH
	push	ebx
	push	esi
	push	edi
	push	ecx
	lea	edi, DWORD PTR [ebp-204]
	mov	ecx, 51					; 00000033H
	mov	eax, -858993460				; ccccccccH
	rep stosd
	pop	ecx
	mov	DWORD PTR _this$[ebp], ecx

; 9    :     ScopedUnprotect::ScopedUnprotect() : ScopedUnprotect(GH3_CODE_START, GH3_CODE_SIZE)

	push	4784128					; 00490000H
	push	4198416					; 00401010H
	mov	ecx, DWORD PTR _this$[ebp]
	call	??0ScopedUnprotect@GH3P@@QAE@PAXK@Z	; GH3P::ScopedUnprotect::ScopedUnprotect

; 11   :     }

	mov	eax, DWORD PTR _this$[ebp]
	pop	edi
	pop	esi
	pop	ebx
	add	esp, 204				; 000000ccH
	cmp	ebp, esp
	call	__RTC_CheckEsp
	mov	esp, ebp
	pop	ebp
	ret	0
??0ScopedUnprotect@GH3P@@QAE@XZ ENDP			; GH3P::ScopedUnprotect::ScopedUnprotect
_TEXT	ENDS
END