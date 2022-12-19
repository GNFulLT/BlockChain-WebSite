import '../styles/globals.css'
import type { AppProps } from 'next/app'
import QueryActiveProvider from '../lib/hooks/Query'
import AuthProvider from '../lib/hooks/Auth'

export default function App({ Component, pageProps }: AppProps) {
  return (
    <QueryActiveProvider>
      <AuthProvider>
        <Component {...pageProps} />
      </AuthProvider>
    </QueryActiveProvider>
  )
}
