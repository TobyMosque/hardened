import './globals.css'
import { Inter } from 'next/font/google'
import WalletProvider from '../context/wallet-provider'
import { INetworkType } from '@/utils/neo/interfaces'

const inter = Inter({ subsets: ['latin'] })

export const metadata = {
  title: 'Create Next App',
  description: 'Generated by create next app',
}

export default function RootLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
    <html lang="en">
      <body className={inter.className}>
        <WalletProvider
          options={{
            network: process.env.NETWORK as INetworkType,
          }}
        >
          {children}
        </WalletProvider>
      </body>
    </html>
  )
}
