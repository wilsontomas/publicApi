import { Injectable, Inject, PLATFORM_ID } from '@angular/core';
import { isPlatformServer } from '@angular/common';

export type Encoding = 'ascii' | 'utf8' | 'hex';

@Injectable({ providedIn: 'root' })
export class Base64UrlService {
  constructor(@Inject(PLATFORM_ID) private platformId: any) {}

  /**
   * Encodes provided input value as base64url string.
   * Note that if encoding used is ascii and provided input contains non-ascii values
   * then non-ascii values are ignored.
   * @param input Input value to encode.
   * @param encoding Character encoding. If not provided then default value 'ascii' is used.
   */
  encode(input: string, encoding: Encoding = 'ascii'): string | null {
    if (!input) {
      return '';
    }

    // Remove non-ascii characters if provided character encoding is ascii
    const valueToEncode: string =
      encoding === 'ascii' ? input.replace(/[^\x00-\x7F]/g, '') : input;
    if (isPlatformServer(this.platformId)) {
      const base64 = Buffer.from(valueToEncode, encoding).toString('base64');
      return this.fromBase64(base64);
    }

    switch (encoding) {
      case 'ascii':
        return this.fromBase64(btoa(valueToEncode));
      case 'utf8':
        const base64 = btoa(
          encodeURIComponent(valueToEncode).replace(
            /%([0-9A-F]{2})/g,
            (_, p1) => String.fromCharCode(parseInt('0x' + p1, 16))
          )
        );
        return this.fromBase64(base64);
      
    }
    return '';
  }

  /**
   * Decodes provided base64 or base64url value.
   * @param input Base64 or base64url
   * @param encoding Character encoding. If not provided then default value 'ascii' is used.
   */
  decode(input: string, encoding: Encoding = 'ascii'): string {
    const base64 = this.toBase64(input);
    if (isPlatformServer(this.platformId)) {
      return Buffer.from(base64, 'base64').toString(encoding);
    }

    switch (encoding) {
      case 'ascii':
        return atob(base64);
      case 'utf8':
        return decodeURIComponent(
          atob(base64)
            .split('')
            .map((c) => '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2))
            .join('')
        );
      case 'hex':
        return atob(base64)
          .split('')
          .map((c) => ('0' + c.charCodeAt(0).toString(16)).slice(-2))
          .join('');
    }
  }

  /**
   * Converts base64 to base64url.
   * @param base64 Base64.
   */
  fromBase64(base64: string): string {
    if (!base64) {
      return base64;
    }

    return base64.replace(/\+/g, '-').replace(/\//g, '_').replace(/=+$/, '');
  }

  /**
   * Converts base64url to base64.
   * @param input Base 64 url encoded value.
   */
  toBase64(input: string): string {
    if (!input) {
      return '';
    }

    let encoded = input.replace(/-/g, '+').replace(/_/g, '/');
    while (encoded.length % 4) {
      encoded = encoded + '=';
    }

    return encoded;
  }
}
